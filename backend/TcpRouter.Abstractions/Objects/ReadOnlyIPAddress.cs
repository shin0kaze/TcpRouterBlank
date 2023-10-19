using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace TcpRouter.Abstractions
{
  public class ReadOnlyIPAddress
  {
    private ReadOnlyIPAddress(string ip)
    {
      Address = ip;
    }

    public static ReadOnlyIPAddress Of(IPAddress ip) => new ReadOnlyIPAddress(ip.ToString());

    public static ReadOnlyIPAddress Parse(string ip)
    {
      if (!Regex.IsMatch(ip, IpPattern))
        throw new FormatException($"Неверный формат IP адреса '{ip}'");

      return new ReadOnlyIPAddress(ip);
    }

    public static ReadOnlyIPAddress Of(uint ip)
    {
      var ipAsStr = new IPAddress(ip).ToString();
      return new ReadOnlyIPAddress(ipAsStr);
    }

    public IPAddress ToIp()
    {
      return IPAddress.Parse(Address);
    }

    /// <summary>
    /// 0.0.0.0
    /// </summary>
    public static ReadOnlyIPAddress Any { get; } = new ReadOnlyIPAddress(IPAddress.Any.ToString());
    /// <summary>
    /// 127.0.0.1
    /// </summary>
    public static ReadOnlyIPAddress Loopback { get; } = new ReadOnlyIPAddress(IPAddress.Loopback.ToString());
    /// <summary>
    /// 255.255.255.255
    /// </summary>
    public static ReadOnlyIPAddress Broadcast { get; } = new ReadOnlyIPAddress(IPAddress.Broadcast.ToString());

    public string Address { get; }

    public override string ToString() => Address;

    public override bool Equals(object? obj)
    {
      return obj is ReadOnlyIPAddress address &&
             Address == address.Address;
    }

    public override int GetHashCode()
    {
      return HashCode.Combine(Address);
    }

    private const string IpPattern = @"^(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)(\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)){3}$";
  }
}
