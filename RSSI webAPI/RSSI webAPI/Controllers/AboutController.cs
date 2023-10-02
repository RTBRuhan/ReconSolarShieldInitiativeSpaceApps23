﻿using Microsoft.AspNetCore.Mvc;

namespace RSSI_webAPI.Controllers;

[Route("rssi")]
public class AboutController : Controller
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult Index()
    {
        return View();
    }
}
