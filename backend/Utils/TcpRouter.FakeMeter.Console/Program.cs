using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Sockets;
using System.Text;
using TcpRouter.FakeMeter.Console;

namespace TcpRouter.FakeMeterConscole
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello! I am fake meter");
      if (args.Length != 2)
      {
        Console.WriteLine(_helpMessage);
        return;
      }

      var ipAndPort = args[0];
      var serialNumber = args[1];

      if (!IsIpAndPortValid(ipAndPort, out var ip, out var port))
      {
        Console.WriteLine("IP and PORT is invalid");
        Console.WriteLine(_helpMessage);
        return;
      }

      if (!IsSerialNumberValid(serialNumber))
      {
        Console.WriteLine("SERIAL NUMBER is invalid");
        Console.WriteLine(_helpMessage);
        return;
      }

      Run(ip, port, serialNumber);
    }

    private static void Run(IPAddress ip, int port, string serialNumber)
    {
      while (true)
      {
        try
        {
          using var _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

          var endPount = new IPEndPoint(ip, port);
          bool isConnected = false;

          while (!isConnected)
          {
            try
            {
              Log($"Connecting to {ip}:{port}");
              _socket.Connect(endPount);
              isConnected = true;
              Log("Connected!");
            }
            catch
            {
              Log("Fail. I wait 5 seconds and try again");
              Thread.Sleep(5000);
            }
          }

          var buffer = new byte[100];
          var received = Receive(_socket, buffer);
          if (received != Proto.Request1)
          {
            throw new Exception(_protocoInteractionlError);
          }
          Log("Identification...");

          Send(_socket, Proto.Response1);

          received = Receive(_socket, buffer);
          if (received != Proto.RequestOfSerialNumber)
          {
            throw new Exception(_protocoInteractionlError);
          }

          Send(_socket, serialNumber);

          Log("Sent the serial number and switched to ECHO mode");
          while (true)
          {
            int count = _socket.Receive(buffer);
            _socket.Send(new ArraySegment<byte>(buffer, 0, count));
          }
        }
        catch (Exception ex)
        {
          Log("Error: " + ex.Message);
        }
      }
    }

    private static bool IsSerialNumberValid(string serialNumber)
    {
      return serialNumber.Length == 14 && serialNumber.All(c => char.IsDigit(c));
    }

    private static bool IsIpAndPortValid(string ipAndPort, [MaybeNullWhen(false)] out IPAddress ip, out ushort port)
    {
      try
      {
        var items = ipAndPort.Split(':');
        var ipAsString = items[0];
        var portAsString = items[1];
        ip = IPAddress.Parse(ipAsString);
        port = ushort.Parse(portAsString);
        return true;
      }
      catch
      {
        ip = default;
        port = default;
        return false;
      }
    }
    private static void Log(string message)
    {
      Console.WriteLine(message);
    }

    private static string Receive(Socket socket, byte[] buffer)
    {
      var count = socket.Receive(buffer);
      var received = Encoding.UTF8.GetString(buffer.AsSpan().Slice(0, count));
      Log($"R: '{received}'");
      return received;
    }

    private static void Send(Socket socket, string content)
    {
      var bytes = Encoding.UTF8.GetBytes(content);
      socket.Send(bytes);
      Log($"S: '{content}'");
    }

    private static string _helpMessage = """
        Run the application with arguments:
        app.exe ip:port serial_number

        The serial number is a 14 digit string.
        
        example:
        app.exe 127.0.0.1:12345 12345678901234

        """;
    private static string _protocoInteractionlError = "At the other end of the line they asked out of protocol";
  }
}