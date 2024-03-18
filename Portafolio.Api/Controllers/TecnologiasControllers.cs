﻿using Microsoft.AspNetCore.Mvc;
using PORTAFOLIO.API.Services;
using PORTAFOLIO.API.Models;

namespace PORTAFOLIO.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TecnologiasControllers : ControllerBase
{

    private readonly ILogger<TecnologiasControllers> _logger;
    private readonly TecnologiaServices _tecnologiasServices;

    public TecnologiasControllers(ILogger<TecnologiasControllers> logger,TecnologiaServices tecnologiasServices)
    {
        _logger = logger;
        _tecnologiasServices = tecnologiasServices;
    }


    [HttpGet]

    public async Task <IActionResult> GetTecnologias()
    {
            var tecnologias = await _tecnologiasServices.GetAsync();
            return Ok(tecnologias);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetTecnologiaByID(string Id)
    {

        return Ok(await _tecnologiasServices.GetTecnologiasById(Id));
    }

    [HttpPost]
    public async Task<IActionResult> CreateTecnologia([FromBody] Tecnologias tecnologias)
    {
        if (tecnologias == null)
            return BadRequest();

        
        if (tecnologias.tecnologia == string.Empty)
        {
         
            ModelState.AddModelError("Name", "El driver no debe estar vacio");
            return BadRequest(ModelState);
        }
        tecnologias.Id = null;
        await _tecnologiasServices.InsertTecnologias(tecnologias);
        return Created("Created", true);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateTecnologia([FromBody] Tecnologias tecnologias)
    {
        if (tecnologias == null)
            return BadRequest();
        if (tecnologias.tecnologia == string.Empty)
            ModelState.AddModelError("Name", "El driver no debe estar vacio");

        

        await _tecnologiasServices.UpdateTecnologias(tecnologias);
        return Created("Created", true);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteTecnologia(string Id)
    {

        await _tecnologiasServices.DelateTecnologias(Id);
        return NoContent();
    }
}