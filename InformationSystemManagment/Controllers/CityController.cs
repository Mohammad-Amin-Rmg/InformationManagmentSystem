using InformationSystemManagment.Data.Context;
using InformationSystemManagment.Dto.CityDto;
using InformationSystemManagment.Dto.State;
using InformationSystemManagment.Services.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace InformationSystemManagment.Controllers;
public class CityController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly ICreateCityService _createCityService;
    private readonly IGetCityService _getCityService;

    public CityController(ApplicationDbContext context, ICreateCityService createCityService,
                          IGetCityService getCityService)
    {
        _context = context;
        _createCityService = createCityService;
        _getCityService = getCityService;
    }

    public async Task<IActionResult> Index()
    {
        var cities = await _getCityService.Execute();
        return View(cities.Data);
    }

    public async Task<IActionResult> Create()
    {
        var stateList = await _context.States.Select(x => new StateListDto
        {
            Id = x.Id,
            Name = x.Name
        }).ToListAsync();

        ViewBag.States = new SelectList(stateList, "Id", "Name");

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(PostCityDto postCity)
    {
        if (ModelState.IsValid)
        {
            await _createCityService.Execute(postCity);
            return RedirectToAction(nameof(Index));
        }

        return View();
    }
}