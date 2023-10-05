using System.Diagnostics.CodeAnalysis;

namespace TcpRouter.Abstractions
{
  /// <summary>
  /// Интерфейс менеджера маршрутов для модуля машрутизации
  /// </summary>
  public interface IRouteManagerForRouter
  {
    /// <summary>
    /// Попытка получить маршрут по его серийному номеру
    /// </summary>
    /// <param name="serialNumber"></param>
    /// <param name="route"></param>
    /// <returns></returns>
    bool TryGetRoute(SerialNumber serialNumber, [MaybeNullWhen(false)] out Route route);

    /// <summary>
    /// Установить статус маршруту по его серийному номеру
    /// </summary>
    /// <param name="serialNumber">серийный номер</param>
    /// <param name="isDeviceConnected">Подключен ли девайс</param>
    /// <param name="isConnectedToDAS">Подклбчен ли маршрут к системе сбора данных</param>
    void SetRouteStatus(SerialNumber serialNumber, bool isDeviceConnected, bool isConnectedToDAS);
  }
}
