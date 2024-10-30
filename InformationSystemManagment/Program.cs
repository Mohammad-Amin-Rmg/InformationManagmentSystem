using InformationSystemManagment.Data.Context;
using InformationSystemManagment.Services.CityService;
using InformationSystemManagment.Services.Continent;
using InformationSystemManagment.Services.Contract;
using InformationSystemManagment.Services.CountryService;
using InformationSystemManagment.Services.Currency;
using InformationSystemManagment.Services.Image;
using InformationSystemManagment.Services.Search;
using InformationSystemManagment.Services.StateService;
using InformationSystemManagment.Services.TownService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
                                                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ISaveImageService, SaveImageService>();
builder.Services.AddScoped<ICreateCountryService, CreateCountryService>();
builder.Services.AddScoped<IGetContinentService, GetContinentService>();
builder.Services.AddScoped<IGetCurrencyService, GetCurrencyService>();
builder.Services.AddScoped<IGetCountryService, GetCountryService>();
builder.Services.AddScoped<IRelativeImagePathService, RelativeImagePathService>();
builder.Services.AddScoped<ICreateStateService, CreateStateService>();
builder.Services.AddScoped<IGetStateService, GetStateService>();
builder.Services.AddScoped<ICreateCityService, CreateCityService>();
builder.Services.AddScoped<IGetCityService, GetCityService>();
builder.Services.AddScoped<ICreateTownService, CreateTownService>();
builder.Services.AddScoped<IGetTownService, GetTownService>();
builder.Services.AddScoped<ISearchService, SearchService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
