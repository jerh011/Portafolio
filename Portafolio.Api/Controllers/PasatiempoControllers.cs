﻿using Microsoft.AspNetCore.Mvc;
using PORTAFOLIO.API.Services;
using PORTAFOLIO.API.Models;

namespace PORTAFOLIO.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PasatiempoControllers : ControllerBase
{

    private readonly ILogger<PasatiempoControllers> _logger;
    private readonly PasatiemposServices _pasatiemposServices;

    public PasatiempoControllers(
        ILogger<PasatiempoControllers> logger,
        PasatiemposServices portafolioServices)
    {
        _logger = logger;
        _pasatiemposServices = portafolioServices;
    }

    [HttpGet]

    public async Task<IActionResult> GetPasatiempos()
    {
        var drivers = await _pasatiemposServices.GetAsync();
        return Ok(drivers);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetPasatiemposByID(string Id)
    {

        return Ok(await _pasatiemposServices.GetpasatiemposById(Id));
    }

    [HttpPost]
    public async Task<IActionResult> CreatePasatiempos([FromBody] Pasatiempos pasatiempos)
    {
        if (pasatiempos == null)
            return BadRequest();
        if (pasatiempos.nombre == string.Empty)
            ModelState.AddModelError("Name", "El driver no debe estar vacio");

        pasatiempos.Id = null;
        await _pasatiemposServices.Insertpasatiempos(pasatiempos);
        return Created("Created", true);
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> UpdatePasatiempos([FromBody] Pasatiempos pasatiempos, string Id)
    {
        if (pasatiempos == null)
            return BadRequest();
        if (pasatiempos.nombre == string.Empty)
            ModelState.AddModelError("Name", "El driver no debe estar vacio");

        pasatiempos.Id = Id;

        await _pasatiemposServices.Updatepasatiempos(pasatiempos);
        return Created("Created", true);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeletePasatiempos(string Id)
    {

        await _pasatiemposServices.Delatepasatiempos(Id);
        return NoContent();
    }
}