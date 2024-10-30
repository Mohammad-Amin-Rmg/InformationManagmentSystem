namespace InformationSystemManagment.Models.Entities;
public class City
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Population { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }

    public int? StateId { get; set; }
    public State? State { get; set; }
    public ICollection<Town>? Towns { get; set; }
}

