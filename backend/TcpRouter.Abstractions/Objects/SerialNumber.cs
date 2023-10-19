using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpRouter.Abstractions
{
  /// <summary>
  /// Серийный номер
  /// </summary>
  public class SerialNumber
  {
    /// <summary>
    /// Создать серийный номер
    /// </summary>
    /// <param name="value"></param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public SerialNumber(string value)
    {
      if (string.IsNullOrEmpty(value))
        throw new ArgumentNullException(nameof(value));

      if (!ValidationHelper.IsSerialNumberValid(value))
        throw new ArgumentException($"Сериный номер должен состоять из {ValidationHelper.SerialNumberExpectedLength} чисел");

      Value = value;
    }

    /// <summary>
    /// Значение серийного номера
    /// </summary>
    public string Value { get; }

    public override bool Equals(object? obj)
    {
      return obj is SerialNumber number &&
             Value == number.Value;
    }

    public override int GetHashCode()
    {
      return HashCode.Combine(Value);
    }
  }
}
