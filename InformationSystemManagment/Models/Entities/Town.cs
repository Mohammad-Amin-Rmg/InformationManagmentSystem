namespace InformationSystemManagment.Models.Entities;
public class Town
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Population { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }

    public int? CityId { get; set; }
    public City? City { get; set; }
}

