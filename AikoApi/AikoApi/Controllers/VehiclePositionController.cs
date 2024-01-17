using AikoApi.Apllication.Dtos;
using AikoApi.Infra.Context;
using AikoApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AikoApi.Controllers;


[ApiController]
[Route("[controller]")]
public class VehiclePositionController : BaseController
{
	public VehiclePositionController(Context context, IMapper mapper) : base(context, mapper)
	{

	}

	/// <summary>
	/// Adiciona uma posiçao de Latitude e Longitude ao veículo no Banco de dados
	/// </summary>
	/// <param name="vehiclePositionDto">Objeto com os campos necessários para criação de uma Linha</param>
	/// <returns>IActionResult</returns>
	/// <response code="201">Caso a inserção seja feita com sucesso</response>
	[HttpPost]
	public IActionResult Create([FromBody] VehiclePositionDto vehiclePositionDto)
	{
		VehiclePosition vehiclePosition = _mapper.Map<VehiclePosition>(vehiclePositionDto);
		var vehicleExists = _context.Vehicles.Any(v => v.Id == vehiclePosition.VehicleId);
		if (!vehicleExists) 
			return NotFound($"Veiculo {vehiclePosition.VehicleId} não foi encontrada.");
		_context.VehiclePositions.Add(vehiclePosition);
		_context.SaveChanges();
		return CreatedAtAction(nameof(GetVehiclePositionId), new { id = vehiclePosition.Id }, vehiclePosition);
	}

	/// <summary>
	/// Consulta a Latitude e Logitude do veículo no Banco de dados
	/// </summary>
	/// <returns>IActionResult</returns>
	/// <response code="200">Caso a consulta seja feita com sucesso</response>
	[HttpGet]
	public IActionResult GetAll()
	{
		var position = _context.VehiclePositions.ToList();
		return Ok(position);
	}

	/// <summary>
	/// Consulta a Latitude e Logitude por ID do veíuclo no Banco de dados
	/// </summary>
	/// <returns>IActionResult</returns>
	/// <response code="200">Caso a consulta seja feita com sucesso</response>
	[HttpGet("{id}")]
	public IActionResult GetVehiclePositionId(long id)
	{
		var position = _context.VehiclePositions.Where(v => v.VehicleId == id);
		if (position == null) return NotFound();
		return Ok(position);
	}

	/// <summary>
	/// Atualiza a posição do veículo informada por ID no Banco de dados
	/// </summary>
	/// <param name="lineDto">Objeto com os campos necessários para criação de uma Linha</param>
	/// <returns>IActionResult</returns>
	/// <response code="200">Caso a atualizaçãp seja feita com sucesso</response>
	[HttpPut("{id}")]
	public IActionResult UpdateVehiclePosition(long id, [FromBody] VehiclePositionDto vehiclePositionDto)
	{
		var vehiclePosition = _context.VehiclePositions.FirstOrDefault(x => x.Id == id);
		if (vehiclePosition == null) 
			return NotFound($"O ID {id} não foi encontrada.");
		_mapper.Map(vehiclePositionDto, vehiclePosition);
		_context.SaveChanges();
		return NoContent();
	}

	/// <summary>
	/// Exclui a posicao do veiculo inforamda por ID do Banco de dados
	/// </summary>
	/// <returns>IActionResult</returns>
	/// <response code="201">Caso a Exxclusão seja feita com sucesso</response>
	[HttpDelete("{id}")]
	public IActionResult DeleteVehiclePosition(long id)
	{
		var vehiclePosition = _context.VehiclePositions.FirstOrDefault(x => x.Id == id);
		if (vehiclePosition == null)
			return NotFound($"Vehicle Postion com o ID {id} não foi encontrada.");
		_context.Remove(vehiclePosition);
		_context.SaveChanges();
		return NoContent();
	}
}
