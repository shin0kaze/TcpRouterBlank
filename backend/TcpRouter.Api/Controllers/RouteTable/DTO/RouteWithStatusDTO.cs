namespace TcpRouter.Api.Controllers.RouteTable.DTO
{
  /// <summary>
  /// Data Transport Object для маршрута со статусами подключения
  /// </summary>
  public class RouteWithStatusDTO : RouteDTO
  {
    /// <summary>
    /// Подключен ли девайс к маршрутизатору?
    /// </summary>
    public bool IsDeviceConnected { get; set; }

    /// <summary>
    /// Поключен ли маршрут к системе сбора данных?
    /// </summary>
    public bool IsRouterConnectedToSSD { get; set; }
  }
}
