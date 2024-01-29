using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OlhoVivo.Core.Application.DTOs;
using OlhoVivo.Core.Application.Interfaces;

namespace WebUI.Controllers;

[Authorize]
public class StopController : Controller
{
    #region Properties
    private IStopService _stopService;
    private ILineService _lineService;
    #endregion

    #region Constructor
    public StopController(IStopService stopService, ILineService lineService)
    {
        _stopService = stopService;
        _lineService = lineService;
    }
    #endregion

    #region Actions

    #region Index
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var stops = await _stopService.GetAll();
        return View(stops);
    }
    #endregion

    #region Create

    [HttpGet()]
    public async Task<ActionResult> Create()
    {
        var lines = await _lineService.GetAll();
        ViewBag.LineId = new SelectList(lines, "Id", "Name");

        return View();
    }

    [HttpPost()]
    public async Task<ActionResult> Create(StopDTO stopDTO)
    {
        if(ModelState.IsValid)
        {
            await _stopService.Create(stopDTO);
            return RedirectToAction(nameof(Index));
        }

        return View(stopDTO);      
    }
    #endregion

    #region Edit

    [HttpGet()]
    public async Task<IActionResult> Edit(long id)
    {
        if (id == null) return NotFound();

        var stopDTO = await _stopService.GetById(id);

        if(stopDTO == null) return NotFound();

        var lines = await _lineService.GetAll();
        ViewBag.LineId = new SelectList(lines, "Id", "Name", stopDTO.LineId);

        return View(stopDTO);
    }

    [HttpPost()]
    public async Task<IActionResult> Edit(StopDTO stopDTO)
    {
        if(ModelState.IsValid)
        {
            await _stopService.Update(stopDTO);
            return RedirectToAction(nameof(Index));
        }

        return View(stopDTO);
    }
    #endregion

    #region Delete
    
    [Authorize(Roles = "Admin")]
    [HttpGet()]
    public async Task<IActionResult> Delete(long id)
    {
        if (id == null) return NotFound();

        var stopDTO =  await _stopService.GetById(id);

        if (stopDTO == null) return NotFound();

        return View(stopDTO);
    }

    [HttpPost(), ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
        await _stopService.Delete(id);
        return RedirectToAction("Index");
    }   
    #endregion

    #region Details

    [HttpGet()]
    public async Task<IActionResult> Details(long id)
    {
        if(id == null) return NotFound();

        var stopDTO = await _stopService.GetById(id);

        if(stopDTO == null) return NotFound();

        return View(stopDTO);
    }
    #endregion

    #endregion
}
