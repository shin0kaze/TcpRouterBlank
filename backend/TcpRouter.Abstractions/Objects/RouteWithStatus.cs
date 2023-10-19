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
    public RouteWithStatus(Route route, bool isDeviceConnected, bool isRouterConnectedToSSD)
    {
      Route = route;
      IsDeviceConnected = isDeviceConnected;
      IsRouterConnectedToSSD = isRouterConnectedToSSD;
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
    public bool IsRouterConnectedToSSD { get; }
  }
}
