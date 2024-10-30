using InformationSystemManagment.Dto;
using InformationSystemManagment.Dto.CityDto;

namespace InformationSystemManagment.Services.Contract
{
    public interface IGetCityService
    {
        Task<ResultDto<List<GetCitiesDto>>> Execute();
    }
}