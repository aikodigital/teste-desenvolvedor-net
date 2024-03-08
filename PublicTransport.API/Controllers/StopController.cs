using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PublicTransport.API.Entities;
using PublicTransport.API.Models.Inputs;
using PublicTransport.API.Models.Views;
using PublicTransport.API.Repositories.Interface;

namespace PublicTransport.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StopController : ControllerBase
{
    private readonly IStopRepository _stopRepository;
    private readonly IMapper _mapper;

    public StopController(IStopRepository stopRepository, IMapper mapper)
    {
        _stopRepository = stopRepository;
        _mapper = mapper;
    }

    // GET: api/Stop
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Stop>>> GetStopsAsync()
    {
        var stops = await _stopRepository.GetAllAsync();

        var viewModel = _mapper.Map<List<StopViewModel>>(stops);

        return Ok(viewModel);
    }

    // GET: api/Stop/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Stop>> GetStopAsync(long id)
    {
        var stop = await _stopRepository.GetByIdAsync(id);

        if (stop == null)
        {
            return NotFound();
        }

        var viewModel = _mapper.Map<StopViewModel>(stop);

        return Ok(viewModel);
    }

    // POST: api/Stop
    [HttpPost]
    public async Task<ActionResult> PostStopAsync(StopInputModel input)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var stop = _mapper.Map<Stop>(input);

        try
        {
            if (input.LineId.HasValue)
            {
                await _stopRepository.CreateWithLineAsync(stop, input.LineId.Value);
            }

            await _stopRepository.CreateAsync(stop);

            return Ok("Parada criada com sucesso!");
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Ocorreu um erro ao criar a parada: " + ex.Message);
        }
    }

    // PUT: api/Stop/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutStopAsync(long id, Stop stop)
    {
        if (id != stop.StopId)
        {
            return BadRequest();
        }

        await _stopRepository.UpdateAsync(stop);

        return NoContent();
    }

    // DELETE: api/Stop/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStopAsync(long id)
    {
        try
        {
            await _stopRepository.DeleteAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Ocorreu um erro ao deletar a parada.");
        }
    }
}
