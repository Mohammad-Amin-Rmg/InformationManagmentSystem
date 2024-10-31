using InformationSystemManagment.Data.Context;
using InformationSystemManagment.Dto.CityDto;
using InformationSystemManagment.Dto.TownDto;
using InformationSystemManagment.Services.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace InformationSystemManagment.Controllers;
public class TownController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly ICreateTownService _createTownService;
    private readonly IGetTownService _getTownService;
    public TownController(ApplicationDbContext context, IGetTownService getTownService,
                         ICreateTownService createTownService)
    {
        _context = context;
        _getTownService = getTownService;
        _createTownService = createTownService;
    }
    public async Task<IActionResult> Index()
    {
        var towns = await _getTownService.Execute();
        return View(towns.Data);
    }

    public async Task<IActionResult> Create()
    {
        var cityList = await _context.Cities.Select(x => new CityListDto
        {
            Id = x.Id,
            Name = x.Name
        }).ToListAsync();

        ViewBag.Cities = new SelectList(cityList, "Id", "Name");

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(PostTownDto postTown)
    {
        if (ModelState.IsValid)
        {
            await _createTownService.Execute(postTown);
            return RedirectToAction(nameof(Index));
        }

        return View();
    }
}
