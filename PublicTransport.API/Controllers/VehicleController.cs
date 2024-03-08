using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PublicTransport.API.Entities;
using PublicTransport.API.Models.Inputs;
using PublicTransport.API.Models.Views;
using PublicTransport.API.Repositories.Interface;

namespace PublicTransport.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VehicleController : ControllerBase
{
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IMapper _mapper;

    public VehicleController(IVehicleRepository vehicleRepository, IMapper mapper)
    {
        _vehicleRepository = vehicleRepository;
        _mapper = mapper;
    }

    // GET: api/Vehicle
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehiclesAsync()
    {
        var vehicles = await _vehicleRepository.GetAllAsync();

        var viewModel = _mapper.Map<List<VehicleViewModel>>(vehicles);

        return Ok(viewModel);
    }

    // GET: api/Vehicle/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Vehicle>> GetVehicleAsync(long id)
    {
        var vehicle = await _vehicleRepository.GetByIdAsync(id);

        if (vehicle == null)
        {
            return NotFound();
        }

        var viewModel = _mapper.Map<VehicleViewModel>(vehicle);

        return Ok(viewModel);
    }

    // POST: api/Vehicle
    [HttpPost]
    public async Task<ActionResult> PostVehicleAsync(VehicleInputModel input)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var vehicle = _mapper.Map<Vehicle>(input);

        try
        {
            await _vehicleRepository.CreateAsync(vehicle);
            return Ok("Veículo criado com sucesso!");
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Ocorreu um erro ao criar o veículo.");
        }
    }

    // PUT: api/Vehicle/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutVehicleAsync(long id, VehicleInputModel input)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var vehicleToUpdate = await _vehicleRepository.GetByIdAsync(id);
        if (vehicleToUpdate == null)
        {
            return NotFound();
        }

        _mapper.Map(input, vehicleToUpdate);
        await _vehicleRepository.UpdateAsync(vehicleToUpdate);

        return NoContent();
    }

    // DELETE: api/Vehicle/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVehicleAsync(long id)
    {
        await _vehicleRepository.DeleteAsync(id);

        return NoContent();
    }
}
