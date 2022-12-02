using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using UnitedCaseStudy.Data.Abstract;
using UnitedCaseStudy.Data.Concrete;
using UnitedCaseStudy.Data.Context;
using UnitedCaseStudy.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMvc();
builder.Services.AddScoped<IRestService, RestService>();
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
    pattern: "{controller=Note}/{action=Index}/{id?}");

app.Run();
