using Microsoft.AspNetCore.Mvc;
using RSSI_webAPI.Repositories.Contracts;

namespace RSSI_webAPI.Controllers;

[Route("api")]
[ApiController]
public class SatelliteDataController : ControllerBase
{
    private readonly ISatelliteDataRepository _repository;
    public SatelliteDataController(ISatelliteDataRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("version")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult Index()
    {
        return Ok("web API - v 1.0.0");
    }

    [HttpGet("data/dscovr")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> GetDscovrData()
    {
        var data = await _repository.GetDscovrRealtimeData();
        if (data == null)
            return NoContent();
        if (data.Error != null)
            return StatusCode(500, new { message = "Internal Server Error", error = data.Error });
        return Ok(data);
    }

    [HttpGet("data/ace")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> GetAceData()
    {
        var data = await _repository.GetAceRealtimeData();
        if (data == null)
            return NoContent();
        if (data.Error != null)
            return StatusCode(500, new { message = "Internal Server Error", error = data.Error });
        return Ok(data);
    }
}
