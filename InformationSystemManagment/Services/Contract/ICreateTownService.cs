using InformationSystemManagment.Dto;
using InformationSystemManagment.Dto.TownDto;

namespace InformationSystemManagment.Services.Contract
{
    public interface ICreateTownService
    {
        Task<ResultDto> Execute(PostTownDto postTown);
    }
}