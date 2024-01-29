using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OlhoVivo.Core.Application.DTOs;
using OlhoVivo.Core.Application.Interfaces;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class VehiclePositionController : ControllerBase
{
    #region Properties
    private IVehiclePositionService _vehiclePositionService;
    #endregion

    #region Constructor
    public VehiclePositionController(IVehiclePositionService vehiclePositionService)
    {
        _vehiclePositionService = vehiclePositionService;
    }
    #endregion

    #region Actions
    [HttpGet]
    public async Task<ActionResult<IEnumerable<VehiclePositionDTO>>> Get()
    {
        try
        {
            var vehiclesPositions  = await _vehiclePositionService.GetAll();

            if  (vehiclesPositions == null)
                return NotFound("Não foi possível encontrar as posições dos veículos");

            return Ok(vehiclesPositions);    
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }

    [HttpGet("{id:long}", Name = "GetVehiclePosition")]
    public async Task<ActionResult<VehiclePositionDTO>> Get(long id)
    {
        try
        {
            var vehiclePosition  = await _vehiclePositionService.GetById(id);

            if  (vehiclePosition == null)
                return NotFound("Posição do Veículo não existe!");

            return Ok(vehiclePosition);        
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }        
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] VehiclePositionDTO vehiclePositionDTO)
    {
        try
        {
            if(vehiclePositionDTO == null)
                return BadRequest("Dados Inválidos");

            await _vehiclePositionService.Create(vehiclePositionDTO);

            return new CreatedAtRouteResult("GetVehiclePosition", new {id = vehiclePositionDTO.Id}, vehiclePositionDTO);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }

    [HttpPut]
    public async Task<ActionResult> Put(long id, [FromBody] VehiclePositionDTO vehiclePositionDTO)
    {
        try
        {
            if(id != vehiclePositionDTO.Id)
                return BadRequest("O ID do parâmetro da requisição não corresponde ao ID da Linha do corpo da requisição");

            if(vehiclePositionDTO == null)
                return BadRequest("Posição do Veículo Inválido!");

            await _vehiclePositionService.Update(vehiclePositionDTO);

            return Ok(vehiclePositionDTO);
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
            var vehiclePositionDTO  = await _vehiclePositionService.GetById(id);

            if  (vehiclePositionDTO == null)
                return NotFound("Posição do Veículo não existe!");

            await _vehiclePositionService.Delete(id);

            return Ok("Posição do Veículo removido com sucesso!");
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }
    #endregion
}
