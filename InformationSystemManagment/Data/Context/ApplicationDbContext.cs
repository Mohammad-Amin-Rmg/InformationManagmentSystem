using InformationSystemManagment.Common;
using InformationSystemManagment.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.ComponentModel;

namespace InformationSystemManagment.Data.Context;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Country> Countries { get; set; }
    public DbSet<State> States { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Town> Towns { get; set; }
    public DbSet<Continent> Continents { get; set; }
    public DbSet<Currency> Currencies { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Continent>().HasData(new Continent { Id = 1, Name = nameof(ContinentsNames.Asia) });
        modelBuilder.Entity<Continent>().HasData(new Continent { Id = 2, Name = nameof(ContinentsNames.Europe) });
        modelBuilder.Entity<Continent>().HasData(new Continent { Id = 3, Name = nameof(ContinentsNames.Africa) });
        modelBuilder.Entity<Continent>().HasData(new Continent { Id = 4, Name = nameof(ContinentsNames.America) });
        modelBuilder.Entity<Continent>().HasData(new Continent { Id = 5, Name = nameof(ContinentsNames.Oceania) });

       
        modelBuilder.Entity<Currency>().HasData(new Currency
        {
            Id = 1,
            Code = nameof(CurrencyCodes.USD),
            Name = nameof(CurrencyNames.USDollar)
        });
        modelBuilder.Entity<Currency>().HasData(new Currency
        {
            Id = 2,
            Code = nameof(CurrencyCodes.IRR),
            Name = nameof(CurrencyNames.IranianRial)
        });

        modelBuilder.Entity<Currency>().HasData(new Currency
        {
            Id = 3,
            Code = nameof(CurrencyCodes.EUR),
            Name = nameof(CurrencyNames.Euro)
        });

        modelBuilder.Entity<Currency>().HasData(new Currency
        {
            Id = 4,
            Code = nameof(CurrencyCodes.GBP),
            Name = nameof(CurrencyNames.UKPoundSterling)
        });

        modelBuilder.Entity<Currency>().HasData(new Currency
        {
            Id = 5,
            Code = nameof(CurrencyCodes.AED),
            Name = nameof(CurrencyNames.UAEDirham)
        });

        modelBuilder.Entity<Currency>().HasData(new Currency
        {
            Id = 6,
            Code = nameof(CurrencyCodes.IQD),
            Name = nameof(CurrencyNames.IraqiDinar)
        });
    }
}