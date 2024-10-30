using InformationSystemManagment.Data.Context;
using InformationSystemManagment.Dto.CityDto;
using InformationSystemManagment.Dto;
using InformationSystemManagment.Models.Entities;
using InformationSystemManagment.Dto.TownDto;
using InformationSystemManagment.Services.Contract;

namespace InformationSystemManagment.Services.TownService;
public class CreateTownService : ICreateTownService
{
    private readonly ApplicationDbContext _context;
    public CreateTownService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ResultDto> Execute(PostTownDto postTown)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(postTown.Name))
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "نام را وارد نمایید"
                };
            }

            if (string.IsNullOrWhiteSpace(postTown.Population))
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "جمعیت را وارد نمایید"
                };
            }

            if (postTown != null)
            {
                var city = new Town
                {
                    Name = postTown.Name,
                    Population = postTown.Population,
                    CityId = postTown.CityId,
                    Latitude = postTown.Latitude,
                    Longitude = postTown.Longitude
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
