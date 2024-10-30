using InformationSystemManagment.Dto;
using InformationSystemManagment.Dto.TownDto;

namespace InformationSystemManagment.Services.Contract
{
    public interface IGetTownService
    {
        Task<ResultDto<List<GetTownsDto>>> Execute();
    }
}