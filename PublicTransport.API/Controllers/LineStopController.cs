using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PublicTransport.API.Models.Inputs;
using PublicTransport.API.Models.Views;
using PublicTransport.API.Repositories.Interface;

namespace PublicTransport.API.Controllers
{
    public class LineStopController : ControllerBase
    {

        private readonly ILineStopRepository _lineStopRepository;
        private readonly IMapper _mapper;

        public LineStopController(ILineStopRepository lineStopRepository, IMapper mapper)
        {
            _lineStopRepository = lineStopRepository;
            _mapper = mapper;
        }

        [HttpGet("stops/{stopId}/lines")]
        public async Task<ActionResult<IEnumerable<LineViewModel>>> GetLinesByStopIdAsync(long stopId)
        {
            var lines = await _lineStopRepository.GetLinesByStopIdAsync(stopId);
            if (lines == null)
            {
                return NotFound($"Nenhuma linha encontrada para a parada com {stopId}.");
            }

            var viewModel = _mapper.Map<IEnumerable<LineViewModel>>(lines);
            return Ok(viewModel);
        }

        [HttpPost("AddStopByLine")]
        public async Task<IActionResult> AddStopByLineAsync([FromBody] LineStopInputModel input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _lineStopRepository.AddStopByLineAsync(input.LineId, input.StopId);
                return Ok("Parada associada à linha com sucesso!");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao associar a parada à linha: " + ex.Message);
            }
        }
    }
}
