using System.Diagnostics.CodeAnalysis;

using TcpRouter.Abstractions;

namespace TcpRouter.RouteManager {
	/// <summary>
	/// Менеджер маршрутов
	/// </summary>
	public class RouteManager : IRouteMangerForApi, IRouteManagerForRouter {
		public void CreateNewRoute(Route route)
		{
			if (RouteStorage.ContainsKey(route.SerialNumber))
				throw new RouteManagerException("Route with this serial already exists");
			if (endPoints.Contains(route.EndPoint))
				throw new RouteManagerException("Endpoint is occupied");

			RouteStorage.Add(route.SerialNumber, new(route, false, false));
			endPoints.Add(route.EndPoint);
		}

		public void DeleteRoute(SerialNumber serial)
		{
			var route = RouteStorage[serial];
			if (route is null)
				throw new RouteManagerException("Route with this serial not found");
			endPoints.Remove(route.Route.EndPoint);
			RouteStorage.Remove(serial);
		}

		public IReadOnlyList<RouteWithStatus> GetAllRoutes()
		{
			return RouteStorage.Values.ToList();
		}

		public void SetRouteStatus(SerialNumber serialNumber, bool isDeviceConnected, bool isConnectedToDAS)
		{
			var route = RouteStorage[serialNumber];
			RouteStorage[serialNumber] = new RouteWithStatus(route.Route, isDeviceConnected, isConnectedToDAS);
		}

		public bool TryGetRoute(SerialNumber serialNumber, [MaybeNullWhen(false)] out Route route)
		{
			RouteStorage.TryGetValue(serialNumber, out var routeWithStatus);
			return (route = routeWithStatus?.Route) != null;
		}

		public void UpdateRoute(SerialNumber serialNumber, Route newState)
		{
			if (!RouteStorage.ContainsKey(serialNumber))
				throw new RouteManagerException("Route with this serial not found");
			if (endPoints.Contains(newState.EndPoint))
				throw new RouteManagerException("Endpoint is occupied");

			var routeWithStatus = RouteStorage[serialNumber];
			endPoints.Remove(routeWithStatus.Route.EndPoint);
			endPoints.Add(newState.EndPoint);
			RouteStorage[serialNumber] = new RouteWithStatus(
				newState,
				routeWithStatus.IsDeviceConnected,
				routeWithStatus.IsRouterConnectedToSSD);
		}

		private Dictionary<SerialNumber, RouteWithStatus> RouteStorage = new();
		private HashSet<ReadOnlyIPEndPoint> endPoints = new();

	}
}