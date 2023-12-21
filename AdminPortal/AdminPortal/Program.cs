using AdminPortal.Localizations;
using AdminPortal.Resources;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;
using System.Reflection;
using System.Text.RegularExpressions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfraLocalization();

// Add services to the container.
builder.Services.AddRazorPages();

//---------------------------------------------------------------------------------------------------------------------------------

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseInfraLocalization();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
