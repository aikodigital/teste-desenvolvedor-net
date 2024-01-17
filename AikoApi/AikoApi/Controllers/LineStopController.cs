using AikoApi.Apllication.Dtos;
using AikoApi.Infra.Context;
using AikoApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AikoApi.Controllers
{

	[ApiController]
	[Route("[controller]")]
	public class LineStopController : ControllerBase
	{
		private Context _context;
		private IMapper _mapper;

		public LineStopController(Context context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}


		/// <summary>
		/// Faz o relacionamento entre Stops com quantidade de Lines
		/// </summary>
		/// <param name="lineStopDto">Objeto com os campos necessários para criação</param>
		/// <returns>IActionResult</returns>
		/// <response code="201">Caso a inserção seja feita com sucesso</response>
		[HttpPut]
		public IActionResult Create([FromBody] LineStopDto lineStopDto)
		{
			LineStop lineStop = _mapper.Map<LineStop>(lineStopDto);
			var lineExists = _context.Lines.Any(l => l.Id == lineStop.LineId);
			var stopExists = _context.Stops.Any(s => s.Id == lineStop.StopId);

			if (!lineExists)
				return NotFound($"Line Id {lineStop.LineId} não existe");

			if (!stopExists)
				return NotFound($"Stop Id {lineStop.StopId} não existe");

			_context.LinesStops.Add(lineStop);
			_context.SaveChanges();
			
			return NoContent();

		}

		/// <summary>
		/// Recebe o identificador de uma Stop e retorna as Lines associadas a parada informada
		/// </summary>
		/// <returns>IActionResult</returns>
		/// <response code="200">Caso a consulta seja feita com sucesso</response>
		[HttpGet("{id}")]
		public IActionResult GetLinesByStopId(long id)
		{			
			var lines = _context.LinesStops
								.Where(ls => ls.StopId == id)
								.Select(ls => new StopLineDto(ls.Line))
								.ToList();

			return Ok(lines);
		}
	}
}
