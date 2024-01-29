using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OlhoVivo.Core.Application.DTOs;
using OlhoVivo.Core.Application.Interfaces;

namespace WebUI.Controllers;

[Authorize]
public class VehiclePositionController : Controller
{
    #region Properties
    private IVehiclePositionService _vehiclePositionService;
    private IVehicleService _vehicleService;
    #endregion

    #region Constructor
    public VehiclePositionController(IVehiclePositionService vehiclePositionService, IVehicleService vehicleService)
    {
        _vehiclePositionService = vehiclePositionService;
        _vehicleService = vehicleService;
    }
    #endregion

    #region Actions

    #region Index
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var vehiclesPositions = await _vehiclePositionService.GetAll();
        return View(vehiclesPositions);
    }
    #endregion

    #region Create

    [HttpGet()]
    public async Task<ActionResult> Create()
    {
        var vehicles = await _vehicleService.GetAll();
        ViewBag.VehicleId = new SelectList(vehicles, "Id", "Name");

        return View();
    }

    [HttpPost()]
    public async Task<ActionResult> Create(VehiclePositionDTO vehiclePositionDTO)
    {
        if(ModelState.IsValid)
        {
            await _vehiclePositionService.Create(vehiclePositionDTO);
            return RedirectToAction(nameof(Index));
        }

        return View(vehiclePositionDTO);
    }
    #endregion

    #region Edit

    [HttpGet()]
    public async Task<IActionResult> Edit(long id)
    {
        if (id == null) return NotFound();

        var vehiclePositionDTO = await _vehiclePositionService.GetById(id);

        if(vehiclePositionDTO == null) return NotFound();

        var vehicles = await _vehicleService.GetAll();
        
        ViewBag.VehicleId = new SelectList(vehicles, "Id", "Name", vehiclePositionDTO.VehicleId);

        return View(vehiclePositionDTO);
    }

    [HttpPost()]
    public async Task<IActionResult> Edit(VehiclePositionDTO vehiclePositionDTO)
    {
        if(ModelState.IsValid)
        {
            await _vehiclePositionService.Update(vehiclePositionDTO);
            return RedirectToAction(nameof(Index));
        }

        return View(vehiclePositionDTO);
    }
    #endregion

    #region Delete

    [Authorize(Roles = "Admin")]
    [HttpGet()]
    public async Task<IActionResult> Delete(long id)
    {
        if (id == null) return NotFound();

        var vehiclePositionDTO =  await _vehiclePositionService.GetById(id);

        if (vehiclePositionDTO == null) return NotFound();

        return View(vehiclePositionDTO);
    }

    [HttpPost(), ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
        await _vehiclePositionService.Delete(id);
        return RedirectToAction("Index");
    }   
    #endregion

    #region Details

    [HttpGet()]
    public async Task<IActionResult> Details(long id)
    {
        if(id == null) return NotFound();

        var vehiclePositionDTO = await _vehiclePositionService.GetById(id);

        if(vehiclePositionDTO == null) return NotFound();

        return View(vehiclePositionDTO);
    }
    #endregion

    #endregion
}
