using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpRouter.Abstractions
{
  /// <summary>
  /// Маршрут и его статусы
  /// </summary>
  public class RouteWithStatus
  {
    public RouteWithStatus(Route route, bool isDeviceConnected, bool isRouterConnectedToDAS)
    {
      Route = route;
      IsDeviceConnected = isDeviceConnected;
      IsRouterConnectedToDAS = isRouterConnectedToDAS;
    }

    /// <summary>
    /// Сам маршрут
    /// </summary>
    public Route Route { get; }

    /// <summary>
    /// Подключен ли девайс к маршрутизатору?
    /// </summary>
    public bool IsDeviceConnected { get; }

    /// <summary>
    /// Поключен ли маршрут к системе сбора данных?
    /// </summary>
    public bool IsRouterConnectedToDAS { get; }
  }
}
