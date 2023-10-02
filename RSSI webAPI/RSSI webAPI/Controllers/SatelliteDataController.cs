using Microsoft.AspNetCore.Mvc;

namespace RSSI_webAPI.Controllers;

[Route("rssi/api")]
[ApiController]
public class SatelliteDataController : ControllerBase
{
    [HttpGet("version")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult Index()
    {
        return Ok("web API - v 1.0.0");
    }
}
