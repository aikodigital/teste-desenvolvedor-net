using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OlhoVivo.Core.Application.DTOs;
using OlhoVivo.Core.Application.Interfaces;

namespace WebAPI.Controllers;


[Route("api/[controller]")]
[ApiController]
[Authorize]
public class StopController : ControllerBase
{
    #region Properties
    private IStopService _stopService;
    #endregion

    #region Constructor
    public StopController(IStopService stopService)
    {
        _stopService = stopService;
    }
    #endregion

    #region Actions
    [HttpGet]
    public async Task<ActionResult<IEnumerable<StopDTO>>> Get()
    {
        try
        {   
            var stops = await _stopService.GetAll();

            if (stops == null)
                return NotFound("Não foi possível encontrar os pontos de paradas");

            return Ok(stops);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }

    [HttpGet("{id:long}", Name = "GetStop")]
    public async Task<ActionResult<StopDTO>>Get(long id)
    {
        try
        {
            var stop = await _stopService.GetById(id);

            if (stop == null)
                return NotFound("Ponto de Parada não existe!");

            return Ok(stop);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }

    [HttpGet("Line/{lineId:long}")]
    public async Task<ActionResult<IEnumerable<StopDTO>>>GetStopsByLine(long lineId)
    {
        try
        {
            var stops = await _stopService.GetStopsByLine(lineId);

            if (stops == null)
                return NotFound($"Não foi possível encontrar os pontos de paradas nesta linha {lineId}");

            return Ok(stops);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] StopDTO stopDTO)
    {
        try
        {
            if(stopDTO == null)
                return BadRequest("Dados Inválidos");

            await _stopService.Create(stopDTO);

            return new CreatedAtRouteResult("GetStop", new {id = stopDTO.Id}, stopDTO);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }        
    }

    [HttpPut]
    public async Task<ActionResult> Put(long id, [FromBody] StopDTO stopDTO)
    {
        try
        {
            if(id != stopDTO.Id)
                return BadRequest("O ID do parâmetro da requisição não corresponde ao ID do corpo da requisição");

            if (stopDTO == null)
                return BadRequest("Dados do ponto de parada inválido!");

            await _stopService.Update(stopDTO);

            return Ok(stopDTO);
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
            var stopDTO = await _stopService.GetById(id);

            if(stopDTO == null)
                return BadRequest("Ponto de Parada não existe!");

            await _stopService.Delete(id);

            return Ok("Ponto de Parada removido com sucesso!");
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }        
    }
    #endregion
}
