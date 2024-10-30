using InformationSystemManagment.ViewModel;

namespace InformationSystemManagment.Services.Contract
{
    public interface ISearchService
    {
        Task<List<SearchResultViewModel>> Execute(string search);
    }
}