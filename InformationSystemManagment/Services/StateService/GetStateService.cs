using InformationSystemManagment.Data.Context;
using InformationSystemManagment.Dto;
using InformationSystemManagment.Dto.State;
using InformationSystemManagment.Services.Contract;
using Microsoft.EntityFrameworkCore;

namespace InformationSystemManagment.Services.StateService;
public class GetStateService : IGetStateService
{
    private readonly ApplicationDbContext _context;
    public GetStateService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ResultDto<List<GetStatesDto>>> Execute()
    {
        var states = await _context.States
            .Include(x => x.Country)
            .Select(x => new GetStatesDto
            {
                Id = x.Id,
                Code = x.Code,
                Name = x.Name,
                Population = x.Population,
                CountryName = x.Country!.Name

            }).ToListAsync();

        return new ResultDto<List<GetStatesDto>>
        {
            Data = states,
            IsSuccess = true,
            Message = "عملیات موفق"
        };
    }
}
