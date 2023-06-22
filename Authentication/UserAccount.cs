using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using GestorDeGastosBS.Data.Context;
using GestorDeGastosBS.Data.Wrapper;
using Microsoft.EntityFrameworkCore;
using GestorDeGastosBS.Data.Models;
using GestorDeGastosBS.Data.Request;
using GestorDeGastosBS.Data.Response;

namespace GestorDeGastosBS.Authentication;

public class UserAccount
{
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public string? Role { get; set; }
}

public interface IUserAccountService
{
    Task<UsuarioResponse> GetByUserName(string userName);
}

public class UserAccountService : IUserAccountService
{
    // private List<UserAccount> _users;

    // public UserAccountService()
    // {
    //     _users = new List<UserAccount>
    //     {
    //         new UserAccount{ UserName = "admin", Password = "admin", Role = "Administrador"},
    //         new UserAccount{ UserName = "user", Password = "user", Role = "User"}
    //     };
    // }

    // public UserAccount? GetByUserName(string userName)
    // {
    //     return _users.FirstOrDefault(x=>x.UserName == userName);
    // }

    private readonly IMyDbContext _dbContext;

    public UserAccountService(IMyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UsuarioResponse> GetByUserName(string userName)
    {
        var usuario = await _dbContext.Usuarios.FirstOrDefaultAsync(u => u.Nickname == userName);


        if (usuario != null)
        {
            return new UsuarioResponse
            {
                UserName = usuario.Nickname,
                Password = usuario.Password,
                Role = usuario.Role
            };
        }

        return null!;
    }

    public async Task<Result<bool>> Login(string nick, string pass)
    {
        try
        {
            var user = await _dbContext.Usuarios.FirstOrDefaultAsync(u => u.Nickname == nick);
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
