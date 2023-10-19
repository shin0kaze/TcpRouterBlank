using System.Diagnostics.CodeAnalysis;
using System.Net.Sockets;
using TcpRouter.Abstractions;

namespace TcpRouter.Detector
{
  /// <summary>
  /// Определятор серийных номеров
  /// </summary>
  public class SerialNumberDetector : ISerialNumberDetector
  {
    public bool TryReadDeviceInfo(Socket openedSocket, [MaybeNullWhen(false)] out SerialNumber serialNumber)
    {
      throw new NotImplementedException();
    }
  }
}