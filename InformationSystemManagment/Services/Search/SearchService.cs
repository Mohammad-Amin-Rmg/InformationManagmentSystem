using InformationSystemManagment.Data.Context;
using InformationSystemManagment.Services.Contract;
using InformationSystemManagment.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace InformationSystemManagment.Services.Search;
public class SearchService : ISearchService
{
    private readonly ApplicationDbContext _context;
    public SearchService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<SearchResultViewModel>> Execute(string search)
    {
        var results = new List<SearchResultViewModel>();

        if (!string.IsNullOrEmpty(search))
        {
            results.AddRange(await _context.Continents
                    .Where(x => x.Name!.Contains(search))
                    .Select(x => new SearchResultViewModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        EntityType = "قاره"
                    }).ToListAsync());

            results.AddRange(await _context.Countries
                    .Where(c => c.Name!.Contains(search) || c.Abbreviation!.Contains(search) ||
                            c.Currency!.Code!.Contains(search))
                    .Select(c => new SearchResultViewModel
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Population = $"جمعیت {c.Population} نفر",
                        EntityType = "کشور",
                        AdditionalInfo = $"پیش شماره {c.Code}"
                    }).ToListAsync());

            results.AddRange(await _context.States
                   .Include(x => x.Country)
                   .Where(s => s.Name!.Contains(search))
                   .Select(s => new SearchResultViewModel
                   {
                       Id = s.Id,
                       Name = s.Name,
                       Population = $"جمعیت {s.Population} نفر",
                       EntityType = "استان",
                       AdditionalInfo = $" کشور {s.Country!.Name}"
                   }).ToListAsync());

            results.AddRange(await _context.Cities
                    .Include(x => x.State)
                    .Where(p => p.Name!.Contains(search))
                    .Select(p => new SearchResultViewModel
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Population = $"جمعیت {p.Population} نفر",
                        EntityType = "شهر",
                        AdditionalInfo = $" استان {p.State!.Name}"
                    }).ToListAsync());

            results.AddRange(await _context.Towns
                .Include(x => x.City)
                .Where(t => t.Name!.Contains(search))
                .Select(t => new SearchResultViewModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    Population = $"جمعیت {t.Population} نفر",
                    EntityType = "روستا",
                    AdditionalInfo = $" شهر {t.City!.Name}"
                }).ToListAsync());

        }

        return results;
    }
}
