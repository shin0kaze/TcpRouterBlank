using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpRouter.Abstractions
{
  /// <summary>
  /// Это класс с методами расширения.
  /// Зачем это нужно и как это работает смотри по ссылке:
  /// https://learn.microsoft.com/ru-ru/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
  /// </summary>
  public static class ReadOnlyIPAddressExtensions
  {
    /// <summary>
    /// 0.0.0.0 ?
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    public static bool IsAny(this ReadOnlyIPAddress v)
    {
      return v.Equals(ReadOnlyIPAddress.Any);
    }

    /// <summary>
    /// 127.0.0.1 ?
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    public static bool IsLocalhost(this ReadOnlyIPAddress v)
    {
      return v.Equals(ReadOnlyIPAddress.Loopback);
    }
  }
}
