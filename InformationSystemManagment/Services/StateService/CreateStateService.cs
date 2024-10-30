using InformationSystemManagment.Data.Context;
using InformationSystemManagment.Dto;
using InformationSystemManagment.Dto.State;
using InformationSystemManagment.Models.Entities;
using InformationSystemManagment.Services.Contract;

namespace InformationSystemManagment.Services.StateService;
public class CreateStateService : ICreateStateService
{
    private readonly ApplicationDbContext _context;
    public CreateStateService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ResultDto> Execute(PostStateDto postState)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(postState.Name))
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "نام را وارد نمایید"
                };
            }

            if (string.IsNullOrWhiteSpace(postState.Population))
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "جمعیت را وارد نمایید"
                };
            }

            if (string.IsNullOrWhiteSpace(postState.Code))
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "پیش شماره را وارد نمایید"
                };
            }

            if (postState != null)
            {
                var state = new State
                {
                    Name = postState.Name,
                    Population = postState.Population,
                    Code = postState.Code,
                    CountryId = postState.CountryId,
                    Latitude = postState.Latitude,
                    Longitude = postState.Longitude
                };

                _context.Add(state);
                await _context.SaveChangesAsync();

                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "ثبت عملیات با موفقیت انجام شد"
                };
            }
        }
        catch (Exception)
        {
            return new ResultDto
            {
                IsSuccess = false,
                Message = "خطا"
            };
        }

        return new ResultDto
        {
            IsSuccess = false,
            Message = "خطا"
        };
    }
}
