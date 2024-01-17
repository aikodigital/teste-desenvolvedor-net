using AikoApi.Apllication.Dtos;
using AikoApi.Infra.Context;
using AikoApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AikoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class StopController : BaseController
{
	public StopController(Context context, IMapper mapper) : base(context, mapper)
	{

	}

	/// <summary>
	/// Adiciona uma Parada ao Banco de dados
	/// </summary>
	/// <param name="stopDto">
	/// Objeto com os campos necessários para criação de uma Parada.
	/// LineId é Obrigatório.
	/// </param>
	/// <returns>IActionResult</returns>
	/// <response code="201">Caso a inserção seja feita com sucesso</response>
	[HttpPost]
	public IActionResult Create([FromBody] StopDto stopDto)
	{
		Stop stop = _mapper.Map<Stop>(stopDto);
        _context.Stops.Add(stop);
		_context.SaveChanges();
		return CreatedAtAction(nameof(GetStopId), new { id = stop.Id }, stop);
	}


	/// <summary>
	/// Consulta todas as Paradas no Banco de dados
	/// </summary>
	/// <returns>IActionResult</returns>
	/// <response code="200">Caso a consulta seja feita com sucesso</response>
	[HttpGet]
	public IActionResult GetAll()
	{
		var stops =  _context.Stops.ToList();
		var model = stops.Select(stop => new StopGetDto(stop)).ToList();
		return Ok(model);
	}


	/// <summary>
	/// Consulta a Parada por ID no Banco de dados
	/// </summary>
	/// <returns>IActionResult</returns>
	/// <response code="200">Caso a consulta seja feita com sucesso</response>
	[HttpGet("{id}")]
	public IActionResult GetStopId(long id)
	{
		var model = _context.Stops.Find(id);
		if (model == null) return NotFound($"A entidade Stop com o ID {id} não foi encontrada.");
		var stop = new StopGetDto(model);
		return Ok(stop);
	}


	/// <summary>
	/// Atualiza  a Parada informada por ID no Banco de dados
	/// </summary>
	/// <param name="stopDto">Objeto com os campos necessários para criação de uma Linha</param>
	/// <returns>IActionResult</returns>
	/// <response code="200">Caso a atualizaçãp seja feita com sucesso</response>
	[HttpPut("{id}")]
	public IActionResult UpdateStop(long id, [FromBody] StopDto stopDto)
	{
		var stop = _context.Stops.FirstOrDefault(s => s.Id == id);
        if (stop == null) 
			return NotFound($"A entidade Stop com o ID {id} não foi encontrada.");
		
		_mapper.Map(stopDto, stop);
		_context.SaveChanges();
		return Ok();
    }


	/// <summary>
	/// Exclui a Parada irformada por ID do Banco de dados
	/// </summary>
	/// <returns>IActionResult</returns>
	/// <response code="201">Caso a Exxclusão seja feita com sucesso</response>
	[HttpDelete("{id}")]
	public IActionResult DeleteStop(long id)
	{
		var stop = _context.Stops.FirstOrDefault(s => s.Id == id);
		if (stop == null) 
			return NotFound($"A entidade Stop com o ID {id} não foi encontrada.");
		_context.Remove(stop);
		_context.SaveChanges();
		return NoContent();
	}
}		
