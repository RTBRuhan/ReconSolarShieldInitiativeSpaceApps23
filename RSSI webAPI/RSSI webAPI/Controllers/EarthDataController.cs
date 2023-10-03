using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RSSI_webAPI.Repositories.Contracts;

namespace RSSI_webAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EarthDataController : ControllerBase
{
    private readonly IMapper _automap;
    private readonly IEarthDataRepository _repository;

    public EarthDataController(IEarthDataRepository repository, IMapper mp)
    {
        _automap = mp;
        _repository = repository;
    }

    [HttpGet("geomagnet/l1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> GetGeoMagneticData()
    {
        var data = await _repository.GetGeoMagneticDataAtLagrangianPointOne();
        if (data == null)
            return NoContent();
        return Ok(data);
    }
}
