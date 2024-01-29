using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OlhoVivo.Core.Application.DTOs;
using OlhoVivo.Core.Application.Interfaces;

namespace WebUI.Controllers;

[Authorize]
public class VehicleController : Controller
{
    #region Properties
    private IVehicleService _vehicleService;
    private ILineService _lineService;
    #endregion

    #region Constructor
    public VehicleController(IVehicleService vehicleService, ILineService lineService)
    {
        _vehicleService = vehicleService;
        _lineService = lineService;
    }
    #endregion

    #region Actions

    #region Index

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var vehicles = await _vehicleService.GetAll();
        return View(vehicles);
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
    public async Task<ActionResult> Create(VehicleDTO vehicleDTO)
    {
        if(ModelState.IsValid)
        {
            await _vehicleService.Create(vehicleDTO);
            return RedirectToAction(nameof(Index));
        }

        return View(vehicleDTO);      
    }
    #endregion

    #region Edit

    [HttpGet()]
    public async Task<IActionResult> Edit(long id)
    {
        if (id == null) return NotFound();

        var vehicleDTO = await _vehicleService.GetById(id);

        if(vehicleDTO == null) return NotFound();

        var lines = await _lineService.GetAll();
        ViewBag.LineId = new SelectList(lines, "Id", "Name", vehicleDTO.LineId);

        return View(vehicleDTO);
    }

    [HttpPost()]
    public async Task<IActionResult> Edit(VehicleDTO vehicleDTO)
    {
        if(ModelState.IsValid)
        {
            await _vehicleService.Update(vehicleDTO);
            return RedirectToAction(nameof(Index));
        }

        return View(vehicleDTO);
    }
    #endregion

    #region Delete

    [Authorize(Roles = "Admin")]
    [HttpGet()]
    public async Task<IActionResult> Delete(long id)
    {
        if (id == null) return NotFound();

        var vehicleDTO =  await _vehicleService.GetById(id);

        if (vehicleDTO == null) return NotFound();

        return View(vehicleDTO);
    }

    [HttpPost(), ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
        await _vehicleService.Delete(id);
        return RedirectToAction("Index");
    }   
    #endregion

    #region Details

    [HttpGet()]
    public async Task<IActionResult> Details(long id)
    {
        if(id == null) return NotFound();

        var vehicleDTO = await _vehicleService.GetById(id);

        if(vehicleDTO == null) return NotFound();

        return View(vehicleDTO);
    }
    #endregion

    #endregion
}
