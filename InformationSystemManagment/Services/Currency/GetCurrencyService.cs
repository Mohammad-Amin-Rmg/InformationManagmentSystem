using InformationSystemManagment.Data.Context;
using InformationSystemManagment.Dto;
using InformationSystemManagment.Dto.Currency;
using InformationSystemManagment.Services.Contract;
using Microsoft.EntityFrameworkCore;

namespace InformationSystemManagment.Services.Currency;
public class GetCurrencyService : IGetCurrencyService
{
    private readonly ApplicationDbContext _context;

    public GetCurrencyService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ResultDto<List<CurrencyDto>>> Execute()
    {
        var currencies = await _context.Currencies.Select(c => new CurrencyDto
        {
            Id = c.Id,
            Code = c.Code,
            Name = c.Name
        }).ToListAsync();

        return new ResultDto<List<CurrencyDto>>
        {
            Data = currencies,
            IsSuccess = true,
            Message = "عملیات با موفقیت انجام شد"
        };
    }
}