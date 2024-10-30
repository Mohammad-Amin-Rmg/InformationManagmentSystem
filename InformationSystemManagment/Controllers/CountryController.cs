using InformationSystemManagment.Dto.CountryDto;
using InformationSystemManagment.Services.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InformationSystemManagment.Controllers;

public class CountryController : Controller
{
    private readonly ICreateCountryService _createCountryService;
    private readonly IGetContinentService _getContinentService;
    private readonly IGetCurrencyService _getCurrencyService;
    private readonly IGetCountryService _getCountryService;
    public CountryController(ICreateCountryService createCountryService, IGetContinentService getContinentService,
                            IGetCurrencyService getCurrencyService, IGetCountryService getCountryService)
    {
        _createCountryService = createCountryService;
        _getContinentService = getContinentService;
        _getCurrencyService = getCurrencyService;
        _getCountryService = getCountryService;
    }

    public async Task<IActionResult> Index()
    {
        var countries = await _getCountryService.Execute();
        return View(countries.Data);
    }

    public async Task<IActionResult> Create()
    {
        var getContinents = await _getContinentService.Execute();
        ViewBag.Continents = new SelectList(getContinents.Data, "Id", "Name");

        var getCurrencies = await _getCurrencyService.Execute();
        ViewBag.Currencies = new SelectList(getCurrencies.Data, "Id", "Code");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(PostCountryDto postCountryDto)
    {
        if (ModelState.IsValid)
        {
            await _createCountryService.Execute(postCountryDto);
            return View();
        }

        return View(postCountryDto);
    }
}