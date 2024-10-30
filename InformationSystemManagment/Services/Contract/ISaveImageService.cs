using InformationSystemManagment.Dto;

namespace InformationSystemManagment.Services.Contract
{
    public interface ISaveImageService
    {
        Task<ResultDto<string>> Execute(IFormFile file);
    }
}