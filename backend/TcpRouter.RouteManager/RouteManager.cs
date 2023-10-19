using System.Diagnostics.CodeAnalysis;
using TcpRouter.Abstractions;

namespace TcpRouter.RouteManager
{
  /// <summary>
  /// Менеджер маршрутов
  /// </summary>
  public class RouteManager : IRouteMangerForApi, IRouteManagerForRouter
  {
    public void CreateNewRoute(Route route)
    {
      throw new NotImplementedException();
    }

    public void DeleteRoute(SerialNumber route)
    {
      throw new NotImplementedException();
    }

    public IReadOnlyList<RouteWithStatus> GetAllRoutes()
    {
      throw new NotImplementedException();
    }

    public void SetRouteStatus(SerialNumber serialNumber, bool isDeviceConnected, bool isConnectedToDAS)
    {
      throw new NotImplementedException();
    }

    public bool TryGetRoute(SerialNumber serialNumber, [MaybeNullWhen(false)] out Route route)
    {
      throw new NotImplementedException();
    }

    public void UpdateRoute(SerialNumber serialNumber, Route newState)
    {
      throw new NotImplementedException();
    }
  }
}