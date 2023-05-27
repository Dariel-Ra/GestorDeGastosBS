
using GestorDeGastosBS.Data.Context;
using GestorDeGastosBS.Data.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace GestorDeGastosBS.Data.Services;

public interface IAuthService
{
    Task<Result<bool>> Login(string nick, string pass);
}

public class AuthService : IAuthService
{
    private readonly IMyDbContext dbContext;

    public AuthService(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Result<bool>> Login(string nick, string pass)
    {
        try
        {
            var user = await dbContext.Usuarios.FirstOrDefaultAsync(u => u.Nombre == nick);
            if (user == null) return Result<bool>.Fail("Credenciales invalidas");
            if (user.Password == pass)
            {
                //Logica para crear la cookies de inicio de sesion...
                return Result<bool>.Sucess(true, "Bienvenido");
            }
            return Result<bool>.Fail("Credenciales invalidas");
        }
        catch
        {
            return Result<bool>.Fail("Credenciales invalidas");
        }
    }


}