using System.Diagnostics.CodeAnalysis;
using System.Net.Sockets;

namespace TcpRouter.Abstractions
{
  /// <summary>
  /// Публичный интерфейс для взаимодействия с определятором
  /// </summary>
  public interface ISerialNumberDetector
  {
    /// <summary>
    /// Определить серийный номер устройства.
    /// Предполагается, что при ошибке определения серийного номера метод не бросает исключений, 
    /// а просто возвращает false
    /// </summary>
    /// <param name="openedSocket">сокет в открытом состоянии</param>
    /// <param name="serialNumber">серийный номер </param>
    /// <returns>true, если серийный номер определён.
    /// false, если серийный номер определить не удалось</returns>
    bool TryReadDeviceInfo(Socket openedSocket, [MaybeNullWhen(false)] out SerialNumber serialNumber);
  }
}