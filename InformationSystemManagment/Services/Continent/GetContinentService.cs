using InformationSystemManagment.Data.Context;
using InformationSystemManagment.Dto;
using InformationSystemManagment.Dto.Continent;
using InformationSystemManagment.Services.Contract;
using Microsoft.EntityFrameworkCore;

namespace InformationSystemManagment.Services.Continent;
public class GetContinentService : IGetContinentService
{
    private readonly ApplicationDbContext _context;
    public GetContinentService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<ResultDto<List<ContinentDto>>> Execute()
    {
        var continents = await _context.Continents.Select(x => new ContinentDto
        {
            Id = x.Id,
            Name = x.Name
        }).ToListAsync();

        return new ResultDto<List<ContinentDto>>
        {
            Data = continents,
            IsSuccess = true,
            Message = "عملیات با موفقیت انجام شد"
        };
    }
}