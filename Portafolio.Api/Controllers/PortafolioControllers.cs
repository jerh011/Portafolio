﻿using Microsoft.AspNetCore.Mvc;
using PORTAFOLIO.API.Services;
using PORTAFOLIO.API.Models;

namespace PORTAFOLIO.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PortafolioControllers : ControllerBase
{
    
    private readonly ILogger<PortafolioControllers> _logger;
    private readonly PortafolioServices _portafolioServices;

    public PortafolioControllers(
        ILogger<PortafolioControllers> logger,
        PortafolioServices portafolioServices)
    {
        _logger= logger;
        _portafolioServices=portafolioServices;
    }

   [HttpGet]

    public async Task <IActionResult> GetDrivers()
    {
            var drivers=await _portafolioServices.GetAsync();
            return Ok(drivers);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetDriversByID(string Id)
    {

        return Ok(await _portafolioServices.GetPerfilById(Id));
    }

    [HttpPost]
    public async Task<IActionResult> CreateDriver([FromBody] Perfil perfil)
    {
        if (perfil == null)
            return BadRequest();
        if (perfil.nombre == string.Empty)
            ModelState.AddModelError("Name", "El driver no debe estar vacio");

        perfil.Id = null;
        await _portafolioServices.InsertPerfil(perfil);
        return Created("Created", true);
    }

     [HttpPut("{Id}")]
    public async Task<IActionResult> UpdateDriver([FromBody] Perfil perfil, string Id)
    {
        if (perfil == null)
            return BadRequest();
        if (perfil.nombre == string.Empty)
            ModelState.AddModelError("Name", "El driver no debe estar vacio");

        perfil.Id = Id;

        await _portafolioServices.UpdatePerfil(perfil);
        return Created("Created", true);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Deletedriver(string Id)
    {

        await _portafolioServices.DelatePerfil(Id);
        return NoContent();
    }
}