namespace InformationSystemManagment.Models.Entities;
public class State
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Population { get; set; }
    public string? Code { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }

    public int? CountryId { get; set; }
    public Country? Country { get; set; }
    public ICollection<City>? Cities { get; set; }
}

