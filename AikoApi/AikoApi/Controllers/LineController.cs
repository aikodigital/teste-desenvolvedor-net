using AikoApi.Apllication.Dtos;

using AikoApi.Infra.Context;
using AikoApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AikoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class LineController : ControllerBase
{
	private  Context _context;
	private IMapper _mapper;

	public LineController(Context context, IMapper mapper)
	{
		_context=context;
		_mapper = mapper;
	}

	/// <summary>
	/// Adiciona uma Linha ao Banco de dados
	/// </summary>
	/// <param name="lineDto">Objeto com os campos necessários para criação de uma Linha</param>
	/// <returns>IActionResult</returns>
	/// <response code="201">Caso a inserção seja feita com sucesso</response>
	[HttpPost]
	public IActionResult Create([FromBody] LineDto lineDto)
	{
		Line line = _mapper.Map<Line>(lineDto);
		_context.Lines.Add(line);
		_context.SaveChanges();
		return CreatedAtAction(nameof(GetLineId), new { id = line.Id }, line);

	}

	/// <summary>
	/// Consulta as Linhas no Banco de dados
	/// </summary>
	/// <returns>IActionResult</returns>
	/// <response code="200">Caso a consulta seja feita com sucesso</response>
	[HttpGet]
	public IActionResult GetAll()
	{

		var lines = _context.Lines.ToList();
		var model = lines.Select(line => new LinesGetDto(line)).ToList();
		return Ok(model);
	}

	/// <summary>
	/// Consulta a Linha por Id no Banco de dados
	/// </summary>
	/// <returns>IActionResult</returns>
	/// <response code="200">Caso a consulta seja feita com sucesso</response>
	[HttpGet("{id}")]
	public IActionResult GetLineId(long id)
	{
		
		var model = _context.Lines.Find(id);
		if (model == null) return NotFound();
		var line = new LinesGetDto(model);
		return Ok(line);
	}

	/// <summary>
	/// Atualiza  Linha informada por ID no Banco de dados
	/// </summary>
	/// <param name="lineDto">Objeto com os campos necessários para criação de uma Linha</param>
	/// <returns>IActionResult</returns>
	/// <response code="200">Caso a atualizaçãp seja feita com sucesso</response>
	[HttpPut("{id}")]
	public IActionResult UpdateLine(long id, [FromBody] LineDto lineDto)
	{
		var line = _context.Lines.FirstOrDefault(l => l.Id == id);
		if (line == null) return NotFound();
		_mapper.Map(lineDto, line);
		_context.SaveChanges();
		return Ok($"A linha ID {line.Id} foi atualizada");
	}

	/// <summary>
	/// Exclui a Linha irformada por ID do Banco de dados
	/// </summary>
	/// <returns>IActionResult</returns>
	/// <response code="201">Caso a Exxclusão seja feita com sucesso</response>
	[HttpDelete("{id}")]
	public IActionResult DeleteLine(long id)
	{
		var line = _context.Lines.FirstOrDefault(l => l.Id == id);
		if (line == null) return NotFound();
		_context.Remove(line);
		_context.SaveChanges();
		return Ok($"A linha ID {line.Id} foi removida.");
	}

}
