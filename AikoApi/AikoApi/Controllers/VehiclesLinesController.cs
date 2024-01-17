using AikoApi.Infra.Context;
using AikoApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AikoApi.Controllers
{
    [ApiController]
	[Route("[controller]")]
	public class VehiclesLinesController : ControllerBase
	{
		private Context _context;
		private IMapper _mapper;

		public VehiclesLinesController(Context context, IMapper mapper)
		{
			_context=context;
			_mapper = mapper;
		}

		/// <summary>
		/// Consulta os veículos associados por ID a linha.
		/// </summary>
		/// <returns>IActionResult</returns>
		/// <response code="200">Caso a consulta seja feita com sucesso</response>
		[HttpGet("{lineId}")]
		public IActionResult GetId(long lineId)
		{
			var vehicles = _context.Vehicles.Where(x => x.LineId == lineId).ToList();
			if (!vehicles.Any()) return NotFound($"Na linha id {lineId}, não existe veiculos assciados.");
			return Ok(vehicles);
		}
	}
}
