using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using GestorDeGastosBS.Data.Context;
using GestorDeGastosBS.Data.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace GestorDeGastosBS.Authentication;

public class UserAccount
{
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public string? Role { get; set; }
}

public class UserAccountService
{
    private List<UserAccount> _users;
    
    public UserAccountService()
    {
        _users = new List<UserAccount>
        {
            new UserAccount{ UserName = "admin", Password = "admin", Role = "Administrador"},
            new UserAccount{ UserName = "user", Password = "user", Role = "User"}
        };
    }

    public UserAccount? GetByUserName(string userName)
    {
        return _users.FirstOrDefault(x=>x.UserName == userName);
    }

    private readonly IMyDbContext _dbContext;

    public UserAccountService(IMyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public UserAccount? GetByUserNameA(string userName)
    {
        var usuario = _dbContext.Usuarios.FirstOrDefault(u => u.Nickname == userName);

        if (usuario != null)
        {
            return new UserAccount
            {
                UserName = usuario.Nickname,
                Password = usuario.Password,
                Role = usuario.Role
            };
        }

        return null;
    }



}