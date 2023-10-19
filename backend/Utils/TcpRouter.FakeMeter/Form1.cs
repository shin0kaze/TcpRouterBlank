using Microsoft.VisualBasic.Logging;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Unicode;

namespace TcpRouter.FakeMeter
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
      ValidateSerialNumberAndIpAndPort();
    }

    private void textBoxSerialNumber_TextChanged(object sender, EventArgs e)
    {
      ValidateSerialNumberAndIpAndPort();
    }

    private void textBoxIpAndPort_TextChanged(object sender, EventArgs e)
    {
      ValidateSerialNumberAndIpAndPort();
    }

    private void ValidateSerialNumberAndIpAndPort()
    {
      if (!IsSerialNumberValid(textBoxSerialNumber.Text))
      {
        toolStripStatusLabel1.Text = "Невалидный серийный номер";
        buttonConnect.Enabled = false;
        return;
      }

      if (!IsIpAndPortValid(textBoxIpAndPort.Text, out _, out _))
      {
        toolStripStatusLabel1.Text = "Невалидный IP-адрес и/или TCP-порт";
        buttonConnect.Enabled = false;
        return;
      }

      toolStripStatusLabel1.Text = "";
      buttonConnect.Enabled = true;
    }

    private bool IsSerialNumberValid(string serialNumber)
    {
      return serialNumber.Length == 14 && serialNumber.All(c => char.IsDigit(c));
    }

    private bool IsIpAndPortValid(string ipAndPort, [MaybeNullWhen(false)] out IPAddress ip, out ushort port)
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

    private async void buttonConnect_Click(object sender, EventArgs e)
    {
      ConnectingInProcess();
      try
      {
        if (!IsIpAndPortValid(textBoxIpAndPort.Text, out var ip, out var port))
          return;

        _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        var endPount = new IPEndPoint(ip, port);
        Log("Подключаюсь");
        await _socket.ConnectAsync(endPount);
        OnConnected();
        Log("Подключились");

        var buffer = new byte[100];
        var count = await _socket.ReceiveAsync(buffer);
        var received = Encoding.UTF8.GetString(buffer.AsSpan().Slice(0, count));
        Log($"Приняли: '{received}'");
        if (received != "PREVED")
        {
          throw new Exception("На другом конце спросили не по протоколу");
        }
        Log("Идентификация...");

        await _socket.SendAsync(Encoding.UTF8.GetBytes("MEDVED"));

        count = await _socket.ReceiveAsync(buffer);
        received = Encoding.UTF8.GetString(buffer.AsSpan().Slice(0, count));
        Log($"Приняли: '{received}'");
        if (received != "GET SERIAL NUMBER")
        {
          throw new Exception("На другом конце спросили не по протоколу");
        }
        Log("Запрос серийного номера...");

        await _socket.SendAsync(Encoding.UTF8.GetBytes(textBoxSerialNumber.Text));

        Log("Отправили серийный номер и перешли в режим ЭХО");
        while (true)
        {
          count = await _socket.ReceiveAsync(buffer);
          await _socket.SendAsync(new ArraySegment<byte>(buffer, 0, count));
        }
      }
      catch (Exception ex)
      {
        Log("Ошибка: " + ex.Message);
      }
      finally
      {
        _socket?.Dispose();
        OnDisconnected();
      }
    }

    private void ConnectingInProcess()
    {
      buttonConnect.Enabled = false;
      buttonDisconnect.Visible = false;

      textBoxIpAndPort.Enabled = false;
      textBoxSerialNumber.Enabled = false;
    }

    private void OnConnected()
    {
      buttonConnect.Enabled = false;
      buttonDisconnect.Visible = true;
    }

    private void OnDisconnected()
    {
      buttonConnect.Enabled = true;
      buttonDisconnect.Visible = false;

      textBoxIpAndPort.Enabled = true;
      textBoxSerialNumber.Enabled = true;
    }

    private void buttonDisconnect_Click(object sender, EventArgs e)
    {
      _socket?.Dispose();
      OnDisconnected();
    }

    private void Log(string message)
    {
      toolStripStatusLabel1.Text = message;
      textBox1.Text += message + Environment.NewLine;
    }

    private Socket? _socket;
  }
}