using System.ComponentModel.DataAnnotations;

namespace InformationSystemManagment.Dto.CityDto;
public class PostCityDto
{
    [Required(ErrorMessage = "نام شهر الزامی است")]
    [MaxLength(50)]
    public string? Name { get; set; }
    public string? Population { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public int StateId { get; set; }
}
