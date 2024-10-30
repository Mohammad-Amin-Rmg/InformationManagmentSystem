using InformationSystemManagment.Dto;
using InformationSystemManagment.Dto.State;

namespace InformationSystemManagment.Services.Contract
{
    public interface ICreateStateService
    {
        Task<ResultDto> Execute(PostStateDto postState);
    }
}