using System.Security.Claims;
using GestorDeGastosBS.Data.Context;
using GestorDeGastosBS.Data.Wrapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace GestorDeGastosBS.Data.Services;

public interface IAuthSessionService
{
    Task<Result<bool>> Login(string nick, string pass);
}

public class AuthSessionService : IAuthSessionService
{
    private readonly IMyDbContext dbContext;
    private readonly IHttpContextAccessor httpContextAccessor;

    public AuthSessionService(IMyDbContext dbContext, IHttpContextAccessor httpContextAccessor)
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