using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PublicTransport.API.Entities;
using PublicTransport.API.Models.Inputs;
using PublicTransport.API.Models.Views;
using PublicTransport.API.Repositories.Interface;

namespace PublicTransport.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LineController : ControllerBase
{
    private readonly ILineRepository _lineRepository;
    private readonly IMapper _mapper;

    public LineController(ILineRepository lineRepository, IMapper mapper)
    {
        _lineRepository = lineRepository;
        _mapper = mapper;
    }

    // GET: api/Line
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Line>>> GetLinesAsync()
    {
        var lines = await _lineRepository.GetAllAsync();

        var viewModel = _mapper.Map<List<LineViewModel>>(lines);

        return Ok(viewModel);
    }

    // GET: api/Line/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Line>> GetLineAsync(long id)
    {
        var line = await _lineRepository.GetByIdAsync(id);

        if (line == null)
        {
            return NotFound();
        }

        var viewModel = _mapper.Map<LineViewModel>(line);

        return Ok(viewModel);
    }

    // POST: api/Line
    [HttpPost]
    public async Task<ActionResult> PostLineAsync(LineInputModel input)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var line = _mapper.Map<Line>(input);

        try
        {
            await _lineRepository.PostAsync(line);
            return Ok("Linha criada com sucesso!");
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Ocorreu um erro ao criar a linha.");
        }
    }

    // PUT: api/Line/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutLineAsync(long id, Line line)
    {
        if (id != line.LineId)
        {
            return BadRequest();
        }

        await _lineRepository.UpdateAsync(line);

        return NoContent();
    }

    // DELETE: api/Line/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLineAsync(long id)
    {
        await _lineRepository.DeleteAsync(id);

        return NoContent();
    }
}
