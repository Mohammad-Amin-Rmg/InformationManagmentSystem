using InformationSystemManagment.Data.Context;
using InformationSystemManagment.Services.Contract;

namespace InformationSystemManagment.Services.Image;
public class RelativeImagePathService : IRelativeImagePathService
{

    private readonly ApplicationDbContext _context;

    public RelativeImagePathService(ApplicationDbContext context)
    {
        _context = context;
    }

    public string GetImagePath(string imagePath, int countryId)
    {
        var country = _context.Countries.Find(countryId);
        var image = country!.ImageAddress;
        string path = "";

        if (image != null)
        {
            path = image.Replace(@"C:\Users\ali\source\repos\InformationSystemManagment\InformationSystemManagment\wwwroot\images\", "");
        }
        return path;
    }
}
