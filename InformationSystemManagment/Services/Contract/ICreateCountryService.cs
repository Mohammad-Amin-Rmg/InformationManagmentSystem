using InformationSystemManagment.Dto;
using InformationSystemManagment.Dto.CountryDto;

namespace InformationSystemManagment.Services.Contract
{
    public interface ICreateCountryService
    {
        Task<ResultDto<ResultCreateCountryDto>> Execute(PostCountryDto postCountryDto);
    }
}