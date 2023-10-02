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

    [HttpGet("data")]
    public async Task<ActionResult> GetSatelliteData()
    {
        return Ok();
    }
}
