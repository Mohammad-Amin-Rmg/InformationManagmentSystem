using InformationSystemManagment.Dto;
using InformationSystemManagment.Dto.CityDto;

namespace InformationSystemManagment.Services.Contract
{
    public interface ICreateCityService
    {
        Task<ResultDto> Execute(PostCityDto postCity);
    }
}