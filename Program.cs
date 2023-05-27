using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using GestorDeGastosBS.Data;
using GestorDeGastosBS.Data.Context;
using Microsoft.EntityFrameworkCore;
using GestorDeGastosBS.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddDbContext<MyDbContext>();
builder.Services.AddScoped<IMyDbContext,MyDbContext>();
builder.Services.AddScoped<IAuthService,AuthService>();


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
using(var serviceSope = app.Services.GetService<IServiceScopeFactory>()!.CreateAsyncScope()){
    var dbContext = serviceSope.ServiceProvider.GetRequiredService<MyDbContext>();
    dbContext.Database.Migrate();
}
app.Run();
