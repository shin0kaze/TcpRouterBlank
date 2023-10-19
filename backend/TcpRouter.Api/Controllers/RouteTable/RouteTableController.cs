using Microsoft.AspNetCore.Mvc;
using TcpRouter.Api.Controllers.RouteTable.DTO;

namespace TcpRouter.Api.Controllers.RouteTable
{
  /// <summary>
  /// Контроллер таблицы маршрутизации
  /// </summary>
  [ApiController]
  [Route("[controller]")]
  public class RouteTableController : ControllerBase
  {
    public RouteTableController(ILogger<RouteTableController> logger)
    {
      _logger = logger;
    }

    /// <summary>
    /// Получить список маршрутов
    /// </summary>
    /// <param name="from">Индекс начала считывания</param>
    /// <param name="count">Необходимое количество маршрутов</param>
    /// <returns>Список маршрутов с кодом ответа</returns>
    [HttpGet("{from}/{count}")]
    public ActionResult<IEnumerable<RouteWithStatusDTO>> Get(uint from, uint count)
    {
      return Ok(Array.Empty<RouteDTO>());
    }

    /// <summary>
    /// Получить маршрут по серийному номеру устройства (ID-маршрута)
    /// </summary>
    /// <param name="serialNumber">Серийный номер устройства (ID-маршрута)</param>
    /// <returns>Маршрут с кодом ответа</returns>
    [HttpGet("{serialNumber}")]
    public ActionResult<RouteWithStatusDTO> Get(string serialNumber)
    {
      return Ok(new RouteDTO());
    }

    /// <summary>
    /// Добавить новый маршрут
    /// </summary>
    /// <param name="route">Описание маршрута</param>
    /// <returns>Код ответа от сервера</returns>
    [HttpPost()]
    public ActionResult Post(RouteDTO route)
    {
      return Ok();
    }

    /// <summary>
    /// Обновить существующий маршрут
    /// </summary>
    /// <param name="route">Описание маршрута</param>
    /// <returns>Код ответа от сервера</returns>
    [HttpPut()]
    public ActionResult Put(RouteDTO route)
    {
      return Ok();
    }


    /// <summary>
    /// Удалить маршрут
    /// </summary>
    /// <param name="serialNumber">Серийный номер устройства (ID-маршрута)</param>
    /// <returns>Код ответа от сервера</returns>
    [HttpDelete()]
    public ActionResult Delete(string serialNumber)
    {
      return Ok();
    }

    private readonly ILogger<RouteTableController> _logger;
  }
}