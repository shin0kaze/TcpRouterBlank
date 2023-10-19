using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpRouter.Abstractions
{
  /// <summary>
  /// Исключение которые бросает менеджер маршрутов при работе с маршрутами
  /// </summary>
  public class RouteManagerException : Exception
  {
    public RouteManagerException()
    {
    }

    public RouteManagerException(string? message)
      : base(message)
    {
    }

    public RouteManagerException(string? message, Exception? innerException)
      : base(message, innerException)
    {
    }
  }
}
