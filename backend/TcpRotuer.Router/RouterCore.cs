using System;
using TcpRouter.Abstractions;

namespace TcpRotuer.Router
{
  /// <summary>
  /// Модуль маршрутизации
  /// </summary>
  public class RouterCore
  {
    /// <summary>
    /// на вход получаете
    /// 1) интерфейс модуля определятора
    /// 2) интерфейс модуля менеджера конфигурации
    /// 3) номер tcp порта
    /// </summary>
    /// <param name="detector"></param>
    /// <param name="routerManager"></param>
    /// <param name="tcpPortForListen"></param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="NotImplementedException"></exception>
    public RouterCore(ISerialNumberDetector detector,
      IRouteManagerForRouter routerManager,
      ushort tcpPortForListen)
    {
      _detector = detector ?? throw new ArgumentNullException(nameof(detector));
      _routerManager = routerManager ?? throw new ArgumentNullException(nameof(routerManager));
      _tcpPortForListen = tcpPortForListen;

      throw new NotImplementedException();

      /* Внимание!
       * 
       * До тех пор, пока твой коллега не напишет Определятор, 
       * который будет работать с реальным счётчиком,
       * используй фейковый детектор, который лежит в проекте 
       * Utils\TcpRouter.FakeDetector
       * 
       * В качестве "фейкового счётчика" используй приложение из проекта 
       * Utils\TcpRouter.FakeMeter
       * 
       * FakeMeter и FakeDetector - созданы друг для друга
       */

      /* Когда нужно написать нечто сложное, полезно описать алгоритм на всевдо-коде,
       * как ниже:
       * 
       * Слушаем tcp порт
       * если кто-то подключился, то
       * создаём новый поток
       * дальнейшую работу делаем в новом потоке
       * отдаём соединение определятору
       * если определятор не смог определить серийный номер, то
       *    закрываем соединение
       * 
       * если определятор смог определить серийный номер, то
       * спрашиваем в менеджере конфигурации маршрут для серийного номера
       * если маршрута нет, то 
       *    закрываем соединение
       *    
       * если маршрут есть, то
       * подключаемся к системе сбора данных
       * после подключения к системе сбора данных (ССД)
       *  передаём данные от ССД к устройству
       *  передаём данные от устройства к ССД
       */
    }

    private readonly ISerialNumberDetector _detector;
    private readonly IRouteManagerForRouter _routerManager;
    private readonly ushort _tcpPortForListen;
  }
}