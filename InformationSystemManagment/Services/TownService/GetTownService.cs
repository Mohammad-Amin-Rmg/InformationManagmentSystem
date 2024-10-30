using InformationSystemManagment.Data.Context;
using InformationSystemManagment.Dto;
using InformationSystemManagment.Dto.TownDto;
using InformationSystemManagment.Services.Contract;
using Microsoft.EntityFrameworkCore;

namespace InformationSystemManagment.Services.TownService;
public class GetTownService : IGetTownService
{
    private readonly ApplicationDbContext _context;
    public GetTownService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ResultDto<List<GetTownsDto>>> Execute()
    {
        var towns = await _context.Towns
            .Include(x => x.City)
            .Select(x => new GetTownsDto
            {
                Id = x.Id,
                Name = x.Name,
                Population = x.Population,
                CityName = x.City!.Name

            }).ToListAsync();

        return new ResultDto<List<GetTownsDto>>
        {
            Data = towns,
            IsSuccess = true,
            Message = "عملیات موفق"
        };
    }
}
