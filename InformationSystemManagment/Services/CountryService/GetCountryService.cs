using InformationSystemManagment.Data.Context;
using InformationSystemManagment.Dto;
using InformationSystemManagment.Dto.CountryDto;
using InformationSystemManagment.Services.Contract;
using Microsoft.EntityFrameworkCore;

namespace InformationSystemManagment.Services.CountryService;
public class GetCountryService : IGetCountryService
{
    private readonly ApplicationDbContext _context;
    private readonly IRelativeImagePathService _imagePathService;
    public GetCountryService(ApplicationDbContext context, IRelativeImagePathService imagePathService)
    {
        _context = context;
        _imagePathService = imagePathService;
    }

    public async Task<ResultDto<List<GetCountriesDto>>> Execute()
    {
        var countries = await _context.Countries
            .Include(x => x.Currency)
            .Include(x => x.Continent)
            .Select(x => new GetCountriesDto
            {
                Id = x.Id,
                Name = x.Name,
                Abbreviation = x.Abbreviation,
                Code = x.Code,
                Population = x.Population,
                ImageAddress = _imagePathService.GetImagePath(x.ImageAddress!, x.Id),
                CurrencyCode = x.Currency!.Code,
                ContinentName = x.Continent!.Name

            }).ToListAsync();

        return new ResultDto<List<GetCountriesDto>>
        {
            Data = countries,
            IsSuccess = true,
            Message = "دریافت لیست کشور ها "
        };
    }
}