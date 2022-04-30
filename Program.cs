using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using UserApp.Data;
using UserApp.Models;
using UserApp.Models.Login;
using UserApp.ViewModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddScoped<LoginModel>();
builder.Services.AddTransient<LoginViewModel>();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<RegisterModel>();
builder.Services.AddTransient<RegisterViewModel>();
builder.Services.AddScoped<User>();
builder.Services.AddTransient<UserViewModel>();

builder.Services.ConfigureApplicationCookie(config =>
{
    config.SlidingExpiration = true;// Add this
    config.ExpireTimeSpan = TimeSpan.FromMinutes(15);
    config.Cookie.HttpOnly = true;

});
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});
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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
