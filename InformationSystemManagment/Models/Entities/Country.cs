namespace InformationSystemManagment.Models.Entities;
public class Country
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Population { get; set; }
    public string? Abbreviation { get; set; }
    public string? Code { get; set; }
    public string? ImageAddress { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }

    public int? CurrencyId { get; set; }
    public Currency? Currency { get; set; }
    public int? ContinentId { get; set; }
    public Continent? Continent { get; set; }
    public ICollection<State>? States { get; set; }
}