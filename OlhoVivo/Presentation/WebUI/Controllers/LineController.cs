using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OlhoVivo.Core.Application.DTOs;
using OlhoVivo.Core.Application.Interfaces;

namespace WebUI.Controllers;

[Authorize]
public class LineController : Controller
{
    #region Properties
    private ILineService _lineService;
    #endregion

    #region Constructor
    public LineController(ILineService lineService)
    {
        _lineService = lineService;
    }
    #endregion

    #region Actions

    #region Index
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var lines = await _lineService.GetAll();
        return View(lines);
    }
    #endregion

    #region Create
    [HttpGet()]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(LineDTO line)
    {
        try
        {
            if (ModelState.IsValid)
            {
                await _lineService.Create(line);
                return RedirectToAction(nameof(Index));
            }

            return View(line);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }
    #endregion

    #region Edit
    [HttpGet()]
    public async Task<IActionResult> Edit(long id)
    {
        try
        {
            if (id == null) return NotFound();

            var lineDTO = await _lineService.GetById(id);

            if(lineDTO == null) return NotFound();

            return View(lineDTO);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }

    [HttpPost()]
    public async Task<IActionResult> Edit(LineDTO lineDTO)
    {
        if(ModelState.IsValid)
        {
            try
            {
                await _lineService.Update(lineDTO);
            }
            catch(Exception)
            {
                throw;
            }

            return RedirectToAction(nameof(Index));

        }

        return View(lineDTO);
    }
    #endregion

    #region Delete
    [Authorize(Roles = "Admin")]
    [HttpGet()]
    public async Task<IActionResult> Delete(long id)
    {
        if (id == null) return NotFound();

        var lineDTO = await _lineService.GetById(id);

        if(lineDTO == null) return NotFound();

        return View(lineDTO);
    }

    [HttpPost(), ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
        await _lineService.Delete(id);
        return RedirectToAction("Index");
    }
    #endregion

    #region Details
    [HttpGet()]
    public async Task<IActionResult> Details(long id)
    {
        if (id == null) return NotFound();

        var lineDTO = await _lineService.GetById(id);

        if(lineDTO == null) return NotFound();

        return View(lineDTO);
    }
    #endregion

    #endregion
}
