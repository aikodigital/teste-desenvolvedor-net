using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PublicTransport.API.Entities;
using PublicTransport.API.Models.Inputs;
using PublicTransport.API.Models.Views;
using PublicTransport.API.Repositories.Interface;

namespace PublicTransport.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VehiclePositionController : ControllerBase
{
    private readonly IVehiclePositionRepository _vehiclePositionRepository;
    private readonly IMapper _mapper;

    public VehiclePositionController(IVehiclePositionRepository vehiclePositionRepository, IMapper mapper)
    {
        _vehiclePositionRepository = vehiclePositionRepository;
        _mapper = mapper;
    }

    // GET: api/VehiclePosition
    [HttpGet]
    public async Task<ActionResult<IEnumerable<VehiclePositionViewModel>>> GetAllVehiclePositions()
    {
        var vehiclePositions = await _vehiclePositionRepository.GetAllAsync();
        var viewModel = _mapper.Map<IEnumerable<VehiclePositionViewModel>>(vehiclePositions);
        return Ok(viewModel);
    }

    // GET: api/VehiclePosition/5
    [HttpGet("{id}")]
    public async Task<ActionResult<VehiclePositionViewModel>> GetVehiclePosition(long id)
    {
        var vehiclePosition = await _vehiclePositionRepository.GetByIdAsync(id);
        if (vehiclePosition == null)
        {
            return NotFound();
        }

        var viewModel = _mapper.Map<VehiclePositionViewModel>(vehiclePosition);
        return Ok(viewModel);
    }

    // POST: api/VehiclePosition
    [HttpPost]
    public async Task<ActionResult<VehiclePositionViewModel>> CreateVehiclePosition(VehiclePositionInputModel input)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var vehiclePosition = _mapper.Map<VehiclePosition>(input);
        await _vehiclePositionRepository.CreateAsync(vehiclePosition);
        var viewModel = _mapper.Map<VehiclePositionViewModel>(vehiclePosition);
        return CreatedAtAction(nameof(GetVehiclePosition), new { id = vehiclePosition.VehiclePositionId }, viewModel);
    }

    // PUT: api/VehiclePosition/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateVehiclePosition(long id, VehiclePositionInputModel input)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var vehiclePosition = await _vehiclePositionRepository.GetByIdAsync(id);
        if (vehiclePosition == null)
        {
            return NotFound();
        }

        _mapper.Map(input, vehiclePosition);
        await _vehiclePositionRepository.UpdateAsync(vehiclePosition);
        return NoContent();
    }

    // DELETE: api/VehiclePosition/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVehiclePosition(long id)
    {
        var vehiclePosition = await _vehiclePositionRepository.GetByIdAsync(id);
        if (vehiclePosition == null)
        {
            return NotFound();
        }

        await _vehiclePositionRepository.DeleteAsync(id);
        return NoContent();
    }
}
