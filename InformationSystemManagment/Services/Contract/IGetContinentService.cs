using InformationSystemManagment.Dto;
using InformationSystemManagment.Dto.Continent;

namespace InformationSystemManagment.Services.Contract
{
    public interface IGetContinentService
    {
        Task<ResultDto<List<ContinentDto>>> Execute();
    }
}