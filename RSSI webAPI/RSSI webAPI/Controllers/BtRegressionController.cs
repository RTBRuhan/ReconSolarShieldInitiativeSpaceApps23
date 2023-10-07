using Microsoft.AspNetCore.Mvc;
using static RSSI_webAPI.RssiRegressionEngine;

namespace RSSI_webAPI.Controllers;

[Route("api/[controller]")]
[ApiController]

public class BtRegressionController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ModelOutput>> Predict([FromBody] ModelInput input)
    {
        try
        {
            // Call the Predict method to make predictions
            ModelOutput prediction = await Task.Run(
                () => RssiRegressionEngine.Predict(input)
            );
            return Ok(prediction);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

