using System.ComponentModel.DataAnnotations;

namespace InformationSystemManagment.Dto.TownDto;
public class PostTownDto
{
    [Required(ErrorMessage = "نام روستا الزامی است")]
    [MaxLength(50)]
    public string? Name { get; set; }
    public string? Population { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public int? CityId { get; set; }
}
