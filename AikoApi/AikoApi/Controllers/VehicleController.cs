using AikoApi.Apllication.Dtos;
using AikoApi.Infra.Context;
using AikoApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AikoApi.Controllers
{
    [ApiController]
	[Route("[controller]")]
	public class VehicleController : BaseController
	{
		public VehicleController(Context context, IMapper mapper) : base(context, mapper)
		{

		}

		/// <summary>
		/// Adiciona um veículo ao Banco de dados
		/// </summary>
		/// <param name="vehicleDto">Objeto com os campos necessários para criação de um veículo</param>
		/// <returns>IActionResult</returns>
		/// <response code="201">Caso a inserção seja feita com sucesso</response>
		[HttpPost]
		public IActionResult Create([FromBody] VehicleDto vehicleDto)
		{
			Vehicle vehicle = _mapper.Map<Vehicle>(vehicleDto);
			var lineExist = _context.Lines.Any(l => l.Id == vehicle.LineId);
			if (!lineExist) 
				return NotFound($"Line com o ID {vehicle.LineId} não foi encontrada.");
			_context.Vehicles.Add(vehicle);
			_context.SaveChanges();
			return CreatedAtAction(nameof(GetVehicleId), new { id = vehicle.Id }, vehicle);
		}

		/// <summary>
		/// Consulta os veículos no Banco de dados
		/// </summary>
		/// <returns>IActionResult</returns>
		/// <response code="200">Caso a consulta seja feita com sucesso</response>
		[HttpGet]
		public IActionResult GetAll()
		{
			var vehicles = _context.Vehicles.ToList();
			return Ok(vehicles);
		}

		/// <summary>
		/// Consulta o veíuclo por Id no Banco de dados
		/// </summary>
		/// <returns>IActionResult</returns>
		/// <response code="200">Caso a consulta seja feita com sucesso</response>
		[HttpGet("{id}")]
		public IActionResult GetVehicleId(long id)
		{
			var vehicle = _context.Vehicles.Find(id);
			if (vehicle == null) return NotFound();
			return Ok(vehicle);
		}


		/// <summary>
		/// Atualiza  o veículo informado por ID no Banco de dados
		/// </summary>
		/// <param name="lineDto">Objeto com os campos necessários para criação de uma Linha</param>
		/// <returns>IActionResult</returns>
		/// <response code="200">Caso a atualizaçãp seja feita com sucesso</response>
		[HttpPut("{id}")]
		public IActionResult UpdateVehicle(long id, [FromBody] VehicleDto vehicleDto)
		{
			var vehicle = _context.Vehicles.FirstOrDefault(x => x.Id == id);
			if (vehicle == null) 
				return NotFound($"Veiculo com o ID {id} não foi encontrada.");
			_mapper.Map(vehicleDto, vehicle);
			_context.SaveChanges();
			return Ok(vehicle);
		}


		/// <summary>
		/// Exclui o veículo irformada por ID do Banco de dados
		/// </summary>
		/// <returns>IActionResult</returns>
		/// <response code="201">Caso a Exxclusão seja feita com sucesso</response>
		[HttpDelete("{id}")]
		public IActionResult DeleteVehicle(long id)
		{
			var vehicle = _context.Vehicles.FirstOrDefault(x => x.Id == id);
			if (vehicle == null) return NotFound();
			_context.Remove(vehicle);
			_context.SaveChanges();
			return NoContent();
		}
	}
}
