using InformationSystemManagment.Data.Context;
using InformationSystemManagment.Dto;
using InformationSystemManagment.Services.Contract;

namespace InformationSystemManagment.Services.Image;
public class SaveImageService : ISaveImageService
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly ApplicationDbContext _context;

    public SaveImageService(IWebHostEnvironment webHostEnvironment, ApplicationDbContext context)
    {
        _webHostEnvironment = webHostEnvironment;
        _context = context;
    }

    public async Task<ResultDto<string>> Execute(IFormFile file)
    {
        if (file != null && file.Length > 0)
        {
            var fileName = $"{Guid.NewGuid()}-{Path.GetFileName(file.FileName)}";
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return new ResultDto<string>
            {
                Data = filePath,
                IsSuccess = true,
                Message = "عملیات با موفقیت انجام شد"
            };
        }

        return new ResultDto<string>
        {
            IsSuccess = false,
            Message = "عملیات ناموفق"
        };
    }
}