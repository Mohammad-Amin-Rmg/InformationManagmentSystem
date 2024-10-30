using InformationSystemManagment.Data.Context;
using InformationSystemManagment.Dto.CountryDto;
using InformationSystemManagment.Dto.State;
using InformationSystemManagment.Services.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace InformationSystemManagment.Controllers;

public class StateController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly ICreateStateService _createStateService;
    private readonly IGetStateService _getStateService;
    public StateController(ApplicationDbContext context, ICreateStateService createStateService,
                         IGetStateService getStateService)
    {
        _context = context;
        _createStateService = createStateService;
        _getStateService = getStateService;
    }

    public async Task<IActionResult> Index()
    {
        var states = await _getStateService.Execute();
        return View(states.Data);
    }

    public async Task<IActionResult> Create()
    {
        var countryList = await _context.Countries.Select(x => new CountryListDto
        {
            Id = x.Id,
            Name = x.Name
        }).ToListAsync();

        ViewBag.Countries = new SelectList(countryList, "Id", "Name");

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(PostStateDto postState)
    {
        if (ModelState.IsValid)
        {
            await _createStateService.Execute(postState);
            return View();
        }

        return View(postState);
    }
}
