using InformationSystemManagment.Dto;
using InformationSystemManagment.Dto.Currency;

namespace InformationSystemManagment.Services.Contract
{
    public interface IGetCurrencyService
    {
        Task<ResultDto<List<CurrencyDto>>> Execute();
    }
}