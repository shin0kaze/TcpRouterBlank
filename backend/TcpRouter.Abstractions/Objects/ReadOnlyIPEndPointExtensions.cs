using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpRouter.Abstractions
{
  public static class ReadOnlyIPEndPointExtensions
  {
    /// <summary>
    /// 127.0.0.1 ?
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    public static bool IsLocalhost(this ReadOnlyIPEndPoint v)
    {
      return v.Ip.IsLocalhost();
    }
  }
}
