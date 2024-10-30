using InformationSystemManagment.Data.Context;
using InformationSystemManagment.Dto;
using InformationSystemManagment.Dto.CityDto;
using InformationSystemManagment.Models.Entities;
using InformationSystemManagment.Services.Contract;

namespace InformationSystemManagment.Services.CityService;
public class CreateCityService : ICreateCityService
{
    private readonly ApplicationDbContext _context;
    public CreateCityService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ResultDto> Execute(PostCityDto postCity)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(postCity.Name))
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "نام را وارد نمایید"
                };
            }

            if (string.IsNullOrWhiteSpace(postCity.Population))
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "جمعیت را وارد نمایید"
                };
            }

            if (postCity != null)
            {
                var city = new City
                {
                    Name = postCity.Name,
                    Population = postCity.Population,
                    StateId = postCity.StateId,
                    Latitude = postCity.Latitude,
                    Longitude = postCity.Longitude
                };

                _context.Add(city);
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
