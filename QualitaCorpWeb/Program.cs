using Microsoft.EntityFrameworkCore;
using QualitaCoprWeb.Repository.Models;
using QualitaCorpWeb.Application.Contracts.Services;
using QualitaCorpWeb.Application.Services;
using QualitaCorpWeb.Repository.Contracts;

var builder = WebApplication.CreateBuilder(args);
var mvcBuilder = builder.Services.AddRazorPages();

builder.Services.AddRazorPages();
if (builder.Environment.IsDevelopment())
{
    mvcBuilder.AddRazorRuntimeCompilation();
}

builder.Services.AddTransient<IModelContext, ModelContext>();
builder.Services.AddTransient<IFacturaService, FacturaService>();
builder.Services.AddTransient<IConsultaService, ConsultaService>();

builder.Services.AddControllersWithViews();

// Add services to the container.
builder.Services.AddDbContext<ModelContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DataBase")));





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
