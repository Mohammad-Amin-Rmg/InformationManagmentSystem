using InformationSystemManagment.Data.Context;
using InformationSystemManagment.Dto;
using InformationSystemManagment.Dto.CountryDto;
using InformationSystemManagment.Models.Entities;
using InformationSystemManagment.Services.Contract;

namespace InformationSystemManagment.Services.CountryService;
public class CreateCountryService : ICreateCountryService
{
    private readonly ApplicationDbContext _context;
    private readonly ISaveImageService _saveImageService;
    public CreateCountryService(ApplicationDbContext context, ISaveImageService saveImageService)
    {
        _context = context;
        _saveImageService = saveImageService;
    }

    public async Task<ResultDto<ResultCreateCountryDto>> Execute(PostCountryDto postCountryDto)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(postCountryDto.Name))
            {
                return new ResultDto<ResultCreateCountryDto>
                {
                    Data = new ResultCreateCountryDto
                    {
                        Id = 0
                    },
                    IsSuccess = false,
                    Message = "نام را وارد نمایید"
                };
            }

            if (string.IsNullOrWhiteSpace(postCountryDto.Population))
            {
                return new ResultDto<ResultCreateCountryDto>
                {
                    Data = new ResultCreateCountryDto
                    {
                        Id = 0
                    },
                    IsSuccess = false,
                    Message = "جمعیت را وارد نمایید"
                };
            }

            if (string.IsNullOrWhiteSpace(postCountryDto.Abbreviation))
            {
                return new ResultDto<ResultCreateCountryDto>
                {
                    Data = new ResultCreateCountryDto
                    {
                        Id = 0
                    },
                    IsSuccess = false,
                    Message = "نام مخفف کشور را وارد نمایید"
                };
            }

            if (string.IsNullOrWhiteSpace(postCountryDto.Code))
            {
                return new ResultDto<ResultCreateCountryDto>
                {
                    Data = new ResultCreateCountryDto
                    {
                        Id = 0
                    },
                    IsSuccess = false,
                    Message = "پیش شماره را وارد نمایید"
                };
            }

            var imageAddress = await _saveImageService.Execute(postCountryDto.File!);

            if (postCountryDto != null)
            {
                var country = new Country
                {
                    Name = postCountryDto.Name,
                    Abbreviation = postCountryDto.Abbreviation,
                    Population = postCountryDto.Population,
                    Latitude = postCountryDto.Latitude,
                    Longitude = postCountryDto.Longitude,
                    ImageAddress = imageAddress.Data,
                    ContinentId = postCountryDto.ContinentId,
                    CurrencyId = postCountryDto.CurrencyId,
                    Code = postCountryDto.Code
                };

                _context.Countries.Add(country);
                await _context.SaveChangesAsync();

                return new ResultDto<ResultCreateCountryDto>
                {
                    Data = new ResultCreateCountryDto { Id = country.Id },
                    IsSuccess = true,
                    Message = "عملیات ثبت کشور با موفقیت انجام شد "
                };
            }
        }
        catch (Exception)
        {
            return new ResultDto<ResultCreateCountryDto>
            {
                Data = new ResultCreateCountryDto { Id = 0 },
                IsSuccess = false,
                Message = "خطا در انجام عملیات "
            };
        }

        return new ResultDto<ResultCreateCountryDto>
        {
            IsSuccess = false,
            Message = "خطا در ثبت اطلاعات کشور "
        };
    }
}