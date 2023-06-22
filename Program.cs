using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using GestorDeGastosBS.Data;
using GestorDeGastosBS.Data.Context;
using Microsoft.EntityFrameworkCore;
using GestorDeGastosBS.Data.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using GestorDeGastosBS.Data.Models;
using GestorDeGastosBS.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddDbContext<MyDbContext>();
builder.Services.AddScoped<IMyDbContext,MyDbContext>();
builder.Services.AddScoped<IAuthService,AuthService>();

builder.Services.AddScoped<IProveedorServices, ProveedorServices>();
builder.Services.AddScoped<IMercanciaServices, MercanciaServices>();


builder.Services.AddScoped<IGastosProveedorServices, GastosProveedorServices>();
builder.Services.AddScoped<IGastosMercanciaServices, GastosMercanciaServices>();
builder.Services.AddScoped<IGastosMiscelaneoServices, GastosMiscelaneoServices>();
builder.Services.AddScoped<INominaServices, NominaServices>();
builder.Services.AddScoped<IEmpleadoServices, EmpleadoServices>();
builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddScoped<IUserAccountService, UserAccountService>();
builder.Services.AddAuthenticationCore();
builder.Services.AddHttpContextAccessor();
// builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
// .AddCookie();


var app = builder.Build();

app.UseRouting();

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

    await MyDbContextSeeder.Inicializar(dbContext);
}
app.Run();
