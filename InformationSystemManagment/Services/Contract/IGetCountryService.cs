using InformationSystemManagment.Dto;
using InformationSystemManagment.Dto.CountryDto;

namespace InformationSystemManagment.Services.Contract
{
    public interface IGetCountryService
    {
        Task<ResultDto<List<GetCountriesDto>>> Execute();
    }
}