using InformationSystemManagment.Data.Context;
using InformationSystemManagment.Dto;
using InformationSystemManagment.Dto.CityDto;
using InformationSystemManagment.Services.Contract;
using Microsoft.EntityFrameworkCore;

namespace InformationSystemManagment.Services.CityService;
public class GetCityService : IGetCityService
{
    private readonly ApplicationDbContext _context;
    public GetCityService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ResultDto<List<GetCitiesDto>>> Execute()
    {
        var cities = await _context.Cities
            .Include(x => x.State)
            .Select(x => new GetCitiesDto
            {
                Id = x.Id,
                Name = x.Name,
                Population = x.Population,
                StateName = x.State!.Name

            }).ToListAsync();

        return new ResultDto<List<GetCitiesDto>>
        {
            Data = cities,
            IsSuccess = true,
            Message = "عملیات موفق"
        };
    }
}
