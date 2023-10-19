using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpRouter.Abstractions
{
  /// <summary>
  /// Интерфейс менеджера маршрутов для модуля API
  /// </summary>
  public interface IRouteMangerForApi
  {
    /// <summary>
    /// Создать новый маршрут.
    /// Если уже существует маршрут с таким же серийный номером, то метод должен бросать исключение <see cref="RouteManagerException"/>
    /// Если уже существует маршрут с таким же IpEndPoint ССД, то метод тоже должен бросать исключение
    /// </summary>
    /// <param name="route"></param>
    /// <exception cref="RouteManagerException">
    /// 1) Если маршрут с таким же серийным номером уже существует.
    /// 2) Если существует любой другой маршрут с таким же EndPoint</exception>
    void CreateNewRoute(Route route);

    /// <summary>
    /// Возвращает все имеющиеся в маршруты в системе (и их статусы)
    /// </summary>
    /// <returns></returns>
    IReadOnlyList<RouteWithStatus> GetAllRoutes();

    /// <summary>
    /// Изменить ip адрес или порт у маршрута.
    /// </summary>
    /// <param name="serialNumber">Серийный номер маршрута, который требуется изменить</param>
    /// <param name="newState">Желаемое новое состояние маршрута</param>
    /// <exception cref="RouteManagerException">
    /// 1) если нарушаются инварианты, описанные в методе <see cref="CreateNewRoute(Route)"/>
    /// 2) если не существует маршрута с заданным серийным номером
    /// </exception>
    public void UpdateRoute(SerialNumber serialNumber, Route newState);

    /// <summary>
    /// Удалить маршрут
    /// </summary>
    /// <param name="route"></param>
    /// <exception cref="RouteManagerException">
    /// Если не существует маршрута с заданным серийным номером
    /// </exception>
    public void DeleteRoute(SerialNumber route);
  }
}
