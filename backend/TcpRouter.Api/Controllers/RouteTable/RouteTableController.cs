using Microsoft.AspNetCore.Mvc;
using TcpRouter.Api.Controllers.RouteTable.DTO;

namespace TcpRouter.Api.Controllers.RouteTable
{
  /// <summary>
  /// ���������� ������� �������������
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
    /// �������� ������ ���������
    /// </summary>
    /// <param name="from">������ ������ ����������</param>
    /// <param name="count">����������� ���������� ���������</param>
    /// <returns>������ ��������� � ����� ������</returns>
    [HttpGet("{from}/{count}")]
    public ActionResult<IEnumerable<RouteWithStatusDTO>> Get(uint from, uint count)
    {
      return Ok(Array.Empty<RouteDTO>());
    }

    /// <summary>
    /// �������� ������� �� ��������� ������ ���������� (ID-��������)
    /// </summary>
    /// <param name="serialNumber">�������� ����� ���������� (ID-��������)</param>
    /// <returns>������� � ����� ������</returns>
    [HttpGet("{serialNumber}")]
    public ActionResult<RouteWithStatusDTO> Get(string serialNumber)
    {
      return Ok(new RouteDTO());
    }

    /// <summary>
    /// �������� ����� �������
    /// </summary>
    /// <param name="route">�������� ��������</param>
    /// <returns>��� ������ �� �������</returns>
    [HttpPost()]
    public ActionResult Post(RouteDTO route)
    {
      return Ok();
    }

    /// <summary>
    /// �������� ������������ �������
    /// </summary>
    /// <param name="route">�������� ��������</param>
    /// <returns>��� ������ �� �������</returns>
    [HttpPut()]
    public ActionResult Put(RouteDTO route)
    {
      return Ok();
    }


    /// <summary>
    /// ������� �������
    /// </summary>
    /// <param name="serialNumber">�������� ����� ���������� (ID-��������)</param>
    /// <returns>��� ������ �� �������</returns>
    [HttpDelete()]
    public ActionResult Delete(string serialNumber)
    {
      return Ok();
    }

    private readonly ILogger<RouteTableController> _logger;
  }
}