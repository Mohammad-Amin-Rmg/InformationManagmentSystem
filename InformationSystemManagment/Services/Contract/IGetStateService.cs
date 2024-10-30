using InformationSystemManagment.Dto;
using InformationSystemManagment.Dto.State;

namespace InformationSystemManagment.Services.Contract
{
    public interface IGetStateService
    {
        Task<ResultDto<List<GetStatesDto>>> Execute();
    }
}