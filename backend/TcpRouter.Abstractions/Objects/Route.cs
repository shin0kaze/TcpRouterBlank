using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpRouter.Abstractions
{
  /// <summary>
  /// Маршрут
  /// </summary>
  public class Route
  {
    public Route(SerialNumber serialNumber, ReadOnlyIPEndPoint endPoint)
    {
      SerialNumber = serialNumber;
      EndPoint = endPoint;
    }

    /// <summary>
    /// Серийный номер устройства.
    /// В системе не должно быть маршрутов с одинаковыми серийными номерами"
    /// </summary>
    public SerialNumber SerialNumber { get; }

    /// <summary>
    /// Комбинация IP-адреса и tcp-порта для подключения к Системе Сбора Данных (ССД)
    /// </summary>
    public ReadOnlyIPEndPoint EndPoint { get; }

    public override bool Equals(object? obj)
    {
      return obj is Route route &&
             EqualityComparer<SerialNumber>.Default.Equals(SerialNumber, route.SerialNumber) &&
             EqualityComparer<ReadOnlyIPEndPoint>.Default.Equals(EndPoint, route.EndPoint);
    }

    public override int GetHashCode()
    {
      return HashCode.Combine(SerialNumber, EndPoint);
    }
  }
}
