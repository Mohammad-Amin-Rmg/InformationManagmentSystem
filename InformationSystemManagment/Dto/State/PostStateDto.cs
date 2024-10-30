using System.ComponentModel.DataAnnotations;

namespace InformationSystemManagment.Dto.State;
public class PostStateDto
{
    [Required(ErrorMessage = "نام استان الزامی است")]
    [MaxLength(50)]
    public string? Name { get; set; }

    public string? Population { get; set; }

    [Required(ErrorMessage = "پیش شماره تماس الزامی است")]
    [RegularExpression(@"^(\+?\d{1,3}|\d{1,3})$", ErrorMessage = "پیش شماره باید تنها شامل 3 رقم باشد")]
    public string? Code { get; set; }

    public int? CountryId { get; set; }
    public double Longitude { get; set; }
    public double Latitude { get; set; }
}
