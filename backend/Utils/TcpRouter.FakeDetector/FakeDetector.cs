using System.Diagnostics.CodeAnalysis;
using System.Net.Sockets;
using System.Text;
using TcpRouter.Abstractions;

namespace TcpRouter.Stubs
{
  public class FakeDetector : ISerialNumberDetector
  {
    public bool TryReadDeviceInfo(Socket openedSocket, [MaybeNullWhen(false)] out SerialNumber serialNumber)
    {
      try
      {
        openedSocket.Send(Preved);

        var buffer = new byte[100];
        int count = openedSocket.Receive(buffer);
        var bytes = buffer.AsSpan().Slice(0, count);

        if (!bytes.SequenceEqual(Medved))
        {
          serialNumber = null;
          return false;
        }

        openedSocket.Send(GetSerial);
        count = openedSocket.Receive(buffer);
        bytes = buffer.AsSpan().Slice(0, count);
        var serialNumberAsString = Encoding.UTF8.GetString(bytes);
        serialNumber = new SerialNumber(serialNumberAsString);
        return true;
      }
      catch (Exception ex)
      {
        serialNumber = null;
        return false;
      }
    }

    private static readonly byte[] Preved = Encoding.UTF8.GetBytes("PREVED");
    private static readonly byte[] Medved = Encoding.UTF8.GetBytes("MEDVED");
    private static readonly byte[] GetSerial = Encoding.UTF8.GetBytes("GET SERIAL NUMBER");

  }
}