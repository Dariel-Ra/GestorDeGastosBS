
using System.Security.Claims;
using GestorDeGastosBS.Data.Context;
using GestorDeGastosBS.Data.Wrapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace GestorDeGastosBS.Data.Services;

public interface IAuthService
{
    Task<Result<bool>> Login(string nick, string pass);
}

public class AuthService : IAuthService
{
    private readonly IMyDbContext dbContext;
    private readonly IHttpContextAccessor httpContextAccessor;

    public AuthService(IMyDbContext dbContext, IHttpContextAccessor httpContextAccessor)
    {
        this.dbContext = dbContext;
        this.httpContextAccessor = httpContextAccessor;
    }

    public async Task<Result<bool>> Login(string nick, string pass)
    {
        try
        {
            var user = await dbContext.Usuarios.FirstOrDefaultAsync(u => u.Nickname == nick);
            if (user == null) return Result<bool>.Fail("Credenciales invalidas");
            if (user.Password == pass)
            {
                //Logica para crear la cookies de inicio de sesion...
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Nickname)
                // Agrega más claims si necesitas información adicional en la cookie
            };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    // Opciones adicionales para configurar la cookie
                };

                await httpContextAccessor.HttpContext!.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return Result<bool>.Success(true, "Bienvenido");
            }
            return Result<bool>.Fail("Credenciales invalidas");
        }
        catch
        {
            return Result<bool>.Fail("Credenciales invalidas");
        }
    }
}