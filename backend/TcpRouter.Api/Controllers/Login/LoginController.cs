using Microsoft.AspNetCore.Mvc;

namespace TcpRouter.Api.Controllers.Login
{
  /// <summary>
  /// Контроллер входа в систему
  /// Выдает страницу с QR-кодом,
  /// в котором закодирована информация о подключении клиентского приложения к серверу
  /// </summary>
  [Route("[controller]")]
  [ApiController]
  public class LoginController : ControllerBase
  {
    [HttpGet]
    public ActionResult Get()
    {
      //TODO: Сгенерировать QR-код с информацией о подключении клиентского приложения к серверу
      //и выдать результат.
      //В нем должен быть закодирован IP-адрес tcp-порт для подключения к серверу (API)
      return Ok();
    }
  }
}
