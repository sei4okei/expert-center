using DataAccess.Context;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string conn = builder.Configuration.GetConnectionString("ExpertCenter");
builder.Services.AddDbContext<PriceListContext>(options => options.UseSqlServer(conn));

builder.Services.AddScoped<IPriceListRepository, PriceListRepository>();
builder.Services.AddScoped<IPriceListColumnRepository, PriceListColumnRepository>();

builder.Services.AddScoped<IPriceListService, PriceListService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=PriceList}/{action=Index}/{id?}");

app.Run();
