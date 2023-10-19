using System.Linq;
using System.Text.RegularExpressions;

namespace TcpRouter.Abstractions
{
  public static class ValidationHelper
  {
    /// <summary>
    /// Длина серийного номера
    /// </summary>
    public const int SerialNumberExpectedLength = 14;

    public static bool IsSerialNumberValid(string serialNumber)
    {
      if (serialNumber.Length != SerialNumberExpectedLength)
        return false;

      return serialNumber.All(c => char.IsDigit(c));
    }

    public static bool IsPortValid(int port)
    {
      return 0 <= port && port <= 65535;
    }
  }
}
