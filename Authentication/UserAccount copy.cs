// using System.Security.Cryptography.X509Certificates;
// using System.Collections.Generic;
// using GestorDeGastosBS.Data.Context;
// using GestorDeGastosBS.Data.Wrapper;
// using Microsoft.EntityFrameworkCore;
// using GestorDeGastosBS.Data.Models;
// using GestorDeGastosBS.Data.Request;

// namespace GestorDeGastosBS.Authentication;

// public class UserAccount
// {
//     public string? UserName { get; set; }
//     public string? Password { get; set; }
//     public string? Role { get; set; }
// }

// public class UserAccountService
// {
//     private List<UserAccount> _users;
    
//     public UserAccountService()
//     {
//         _users = new List<UserAccount>
//         {
//             new UserAccount{ UserName = "admin", Password = "admin", Role = "Administrador"},
//             new UserAccount{ UserName = "user", Password = "user", Role = "User"}
//         };
//     }

//     public UserAccount? GetByUserName(string userName)
//     {
//         return _users.FirstOrDefault(x=>x.UserName == userName);
//     }

//     // private readonly IMyDbContext _dbContext;

//     // public UserAccountService(IMyDbContext dbContext)
//     // {
//     //     _dbContext = dbContext;
//     // }

//     // public async Task<Usuario> GetByUserName(string userName)
//     // {
//     //     var usuario = await _dbContext.Usuarios.FirstOrDefaultAsync(u => u.Nickname == userName);


//     //     if (usuario != null)
//     //     {
//     //         return new Usuario
//     //         {
//     //             UserName = usuario.Nickname,
//     //             Password = usuario.Password,
//     //             Role = usuario.Role
//     //         };
//     //     }

//     //     return null!;
//     // }

// }

// // public class UserAccountService
// // {
// //     private readonly IMyDbContext _dbContext;

// //     public UserAccountService(IMyDbContext dbContext)
// //     {
// //         _dbContext = dbContext;
// //     }

// //     public Usuario? GetByUserName(string userName)
// //     {
// //         return _dbContext.Usuarios.FirstOrDefault(x => x.UserName == userName);

// //         // var usuarios = await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.UserName == userName);
// //         // if (usuarios == null) return Result<Usuario>.Fail("Credenciales Incorrectos");

// //         // return Result<Usuario>.Success(usuarios);
// //     }
    
// // }
