using System;
using TcpRouter.Abstractions;

namespace TcpRotuer.Router
{
  /// <summary>
  /// Модуль маршрутизации
  /// </summary>
  public class RouterCore
  {
    public RouterCore(ISerialNumberDetector detector, IRouteManagerForRouter routerManager,
      ushort tcpPortForListen)
    {
      _detector = detector ?? throw new ArgumentNullException(nameof(detector));
      _routerManager = routerManager ?? throw new ArgumentNullException(nameof(routerManager));
      _tcpPortForListen = tcpPortForListen;

      throw new NotImplementedException();
    }

    private readonly ISerialNumberDetector _detector;
    private readonly IRouteManagerForRouter _routerManager;
    private readonly ushort _tcpPortForListen;
  }
}