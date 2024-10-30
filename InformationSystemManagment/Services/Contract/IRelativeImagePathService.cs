namespace InformationSystemManagment.Services.Contract
{
    public interface IRelativeImagePathService
    {
        string GetImagePath(string imagePath, int countryId);
    }
}