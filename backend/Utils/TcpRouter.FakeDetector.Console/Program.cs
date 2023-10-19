using System;
using System.Net.Sockets;
using System.Net;
using System.Threading.Tasks;
using System.Text;
using System.Threading;
using TcpRouter.Stubs;

namespace TcpRouter.FakeDetectorConsole
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello! I am fake detector");
      try
      {
        int port = 12345;

        Console.WriteLine($"Жду подключения на порт {port}");

        var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        socket.Bind(new IPEndPoint(IPAddress.Any, port));
        socket.Listen();
        var connected = socket.Accept();

        var determiner = new FakeDetector();
        if (determiner.TryReadDeviceInfo(connected, out var serialNumber))
        {
          Console.WriteLine("Прочитан! " + serialNumber.Value);
        }
        else
        {
          Console.WriteLine("Не прочитан");
        }

        Console.WriteLine("Перехожу в режим ЭХО\n" +
          "Нажми Enter для завершения работы");

        Task.Run(() =>
        {
          Console.ReadLine();
          Environment.Exit(0);
        });

        var buffer = new byte[100];
        while (true)
        {
          Thread.Sleep(5000);
          var bytes = Encoding.Default.GetBytes(DateTime.Now.ToString());
          connected.Send(bytes);
          Console.WriteLine($"T => {BitConverter.ToString(bytes)}");

          int count = connected.Receive(buffer);
          Console.WriteLine($"R <= {BitConverter.ToString(buffer.AsSpan().Slice(0, count).ToArray())}");
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        Console.ReadLine();
      }

    }
  }
}