using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OlhoVivo.Core.Application.DTOs;
using OlhoVivo.Core.Application.Interfaces;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class LineController : ControllerBase
{
    #region Properties
    private ILineService _lineService;
    #endregion

    #region Constructor
    public LineController(ILineService lineService)
    {
        _lineService = lineService;   
    }
    #endregion

    #region Actions
    [HttpGet]
    public async Task<ActionResult<IEnumerable<LineDTO>>> Get()
    {
        try
        {
            var lines  = await _lineService.GetAll();

            if  (lines == null)
                return NotFound("Não foi possível encontrar as linhas");

            return Ok(lines);        
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }

    [HttpGet("{id:long}", Name = "GetLine")]
    public async Task<ActionResult<LineDTO>> Get(long id)
    {
        try
        {
            var line  = await _lineService.GetById(id);

            if  (line == null)
                return NotFound("Essa Linha não existe!");

            return Ok(line);        
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] LineDTO lineDTO)
    {
        try
        {
            if(lineDTO == null)
                return BadRequest("Dados Inválidos");

            await _lineService.Create(lineDTO);

            return new CreatedAtRouteResult("GetLine", new {id = lineDTO.Id}, lineDTO);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }

    [HttpPut]
    public async Task<ActionResult> Put(long id, [FromBody] LineDTO lineDTO)
    {
        try
        {
            if(id != lineDTO.Id)
                return BadRequest("O ID do parâmetro da requisição não corresponde ao ID da Linha do corpo da requisição");

            if(lineDTO == null)
                return BadRequest("Dados da Linha Inválido!");

            await _lineService.Update(lineDTO);

            return Ok(lineDTO);
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
            var lineDTO  = await _lineService.GetById(id);

            if  (lineDTO == null)
                return NotFound("Essa Linha não existe!");

            await _lineService.Delete(id);

            return Ok("Linha removida com sucesso!");
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }
    #endregion
}
