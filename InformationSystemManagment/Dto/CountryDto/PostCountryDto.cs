using System.ComponentModel.DataAnnotations;

namespace InformationSystemManagment.Dto.CountryDto;
public class PostCountryDto
{
    [Required(ErrorMessage = "نام کشور الزامی است")]
    [MaxLength(50)]
    public string? Name { get; set; }
    public string? Population { get; set; }

    [Required(ErrorMessage = "نام مخفف کشور الزامی است")]
    [RegularExpression(@"^[A-Z]{2,3}$", ErrorMessage = "مخفف باید شامل 2 یا 3 حرف بزرگ باشد")]
    public string? Abbreviation { get; set; }

    [Required(ErrorMessage = "پیش شماره تماس الزامی است")]
    [RegularExpression(@"^(\+?\d{1,3}|\d{1,4})$", ErrorMessage = "پیش شماره باید با + شروع شود و تنها شامل اعداد باشد")]
    public string? Code { get; set; }

    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public int CurrencyId { get; set; }
    public int ContinentId { get; set; }
    public IFormFile? File { get; set; }
}