using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OlhoVivo.Core.Application.DTOs;
using OlhoVivo.Core.Application.Interfaces;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class VehicleController : ControllerBase
{
    #region Properties
    private IVehicleService _vehicleService;
    #endregion

    #region Constructor
    public VehicleController(IVehicleService vehicleService)
    {
        _vehicleService = vehicleService;
    }
    #endregion

    #region Actions
    [HttpGet]
    public async Task<ActionResult<IEnumerable<VehicleDTO>>> Get()
    {
        try
        {
            var vehicles  = await _vehicleService.GetAll();

            if  (vehicles == null)
                return NotFound("Não foi possível encontrar os veículos");

            return Ok(vehicles);        
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }        
    }

    [HttpGet("{id:long}", Name = "GetVehicle")]
    public async Task<ActionResult<VehicleDTO>> Get(long id)
    {
        try
        {
            var vehicle  = await _vehicleService.GetById(id);

            if  (vehicle == null)
                return NotFound("Veículo não existe!");

            return Ok(vehicle);        
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }

    [HttpGet("Line/{lineId:long}")]
    public async Task<ActionResult<IEnumerable<VehicleDTO>>> GetVehiclesByLine(long lineId)
    {
        try
        {
            var vehicles  = await _vehicleService.GetVehiclesByLine(lineId);

            if  (vehicles == null)
                return NotFound($"Não foi possível encontrar os veículos nesta linha {lineId}");

            return Ok(vehicles);        
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }        
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] VehicleDTO vehicleDTO)
    {
        try
        {
            if(vehicleDTO == null)
                return BadRequest("Dados Inválidos");

            await _vehicleService.Create(vehicleDTO);

            return new CreatedAtRouteResult("GetVehicle", new {id = vehicleDTO.Id}, vehicleDTO);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }        
    }

    [HttpPut]
    public async Task<ActionResult> Put(long id, [FromBody] VehicleDTO vehicleDTO)
    {
        try
        {
            if(id != vehicleDTO.Id)
                return BadRequest("O ID do parâmetro da requisição não corresponde ao ID da Linha do corpo da requisição");

            if(vehicleDTO == null)
                return BadRequest("Veículo Inválido!");

            await _vehicleService.Update(vehicleDTO);

            return Ok(vehicleDTO);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }        
    }

    [HttpDelete("{id:long}")]
    public async Task<ActionResult> Delete(long id)
    {
        try
        {
            var vehicleDTO  = await _vehicleService.GetById(id);

            if  (vehicleDTO == null)
                return NotFound("Veículo não existe!");

            await _vehicleService.Delete(id);

            return Ok("Veículo removido com sucesso!");
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }
    #endregion
}
