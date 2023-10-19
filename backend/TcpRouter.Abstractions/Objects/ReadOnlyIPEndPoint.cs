using System;
using System.Collections.Generic;
using System.Net;

namespace TcpRouter.Abstractions
{
  /// <summary>
  /// EndPoint (Конечная точка доступа) - это комбинация IP-адреса и порта
  /// </summary>
  public class ReadOnlyIPEndPoint
  {
    public ReadOnlyIPEndPoint(ReadOnlyIPAddress ip, int port)
    {
      Ip = ip ?? throw new ArgumentNullException(nameof(port));

      if (!ValidationHelper.IsPortValid(port))
        throw new ArgumentException(nameof(port));

      Port = port;
    }

    public static ReadOnlyIPEndPoint Of(IPEndPoint endpoint)
    {
      return new ReadOnlyIPEndPoint(ReadOnlyIPAddress.Of(endpoint.Address), endpoint.Port);
    }

    public static ReadOnlyIPEndPoint Of(ReadOnlyIPAddress ip, int port)
    {
      return new ReadOnlyIPEndPoint(ip, port);
    }

    public static ReadOnlyIPEndPoint Of(string ip, int port)
    {
      return new ReadOnlyIPEndPoint(ReadOnlyIPAddress.Parse(ip), port);
    }

    public IPEndPoint ToEP()
    {
      return new IPEndPoint(Ip.ToIp(), Port);
    }

    public ReadOnlyIPAddress Ip { get; }
    public int Port { get; }

    public override string ToString()
    {
      return $"{Ip}:{Port}";
    }

    public override int GetHashCode()
    {
      return HashCode.Combine(Ip, Port);
    }

    public override bool Equals(object? obj)
    {
      return obj is ReadOnlyIPEndPoint point &&
             EqualityComparer<ReadOnlyIPAddress>.Default.Equals(Ip, point.Ip) &&
             Port == point.Port;
    }
  }
}
