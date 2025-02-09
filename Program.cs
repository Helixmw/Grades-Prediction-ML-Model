using Microsoft.Extensions.ML;
using StudentGradesApp.Logic;
using SudentGradesApp.Controllers;
using SudentGradesApp.Logic;
using SudentGradesApp.Models;
using static SchoolGradesModelLib.SchoolGradesModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

var webRootPath = builder.Environment.WebRootPath;

var modelPath = Path.Combine(webRootPath, "ML", "SchoolGradesModel.mlnet");

builder.Services.AddPredictionEnginePool<ModelInput,ModelOutput>().FromFile(modelPath);
builder.Services.AddScoped<MLModelProcessor>();
builder.Services.AddScoped<HomeController>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
