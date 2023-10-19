namespace TcpRouter.Api.Controllers.RouteTable.DTO
{
  /// <summary>
  /// Data Transport Object для маршрута
  /// </summary>
  public class RouteDTO
  {
    /// <summary>
    /// IP-адрес для подключения к Системе Сбора Данных (ССД)
    /// </summary>
    public string IPAddress { get; set; } = string.Empty;

    /// <summary>
    /// TCP-порт для подключения к Системе Сбора Данных (ССД)
    /// </summary>
    public ushort Port { get; set; } = ushort.MinValue;

    /// <summary>
    /// Серийный номер устройства
    /// </summary>
    public string SerialNumber { get; set; } = string.Empty;
  }
}
