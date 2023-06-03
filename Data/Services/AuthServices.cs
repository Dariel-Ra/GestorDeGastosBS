// using GestorDeGastosBS.Data.Context;
// using Microsoft.AspNetCore.Authentication;
// using Microsoft.AspNetCore.Authentication.Cookies;
// using Microsoft.AspNetCore.Components;
// using Microsoft.AspNetCore.Components.Authorization;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.Configuration;
// using System.Collections.Generic;
// using System.Security.Claims;
// using System.Threading.Tasks;

// namespace GestorDeGastosBS.Data.Services;
// public class AuthService
// {
//     private readonly IConfiguration _configuration;
//     private readonly IMyDbContext _dbContext;
//     private readonly IHttpContextAccessor _httpContextAccessor;

//     public AuthService(IConfiguration configuration, IMyDbContext dbContext, IHttpContextAccessor httpContextAccessor)
//     {
//         _configuration = configuration;
//         _dbContext = dbContext;
//         _httpContextAccessor = httpContextAccessor;
//     }

//     public async Task<bool> LoginAsync(string nickname, string password)
//     {
//         // Aquí debes implementar la lógica para verificar las credenciales del usuario
//         // Consulta la base de datos o cualquier otro método de autenticación
        
// var user = await _dbContext.Usuarios.SingleOrDefaultAsync(u => u.Nickname == nickname && u.Password == password);
    
//     if (user != null)
//     {
//         var claims = new List<Claim>
//         {
//             new Claim(ClaimTypes.Name, user.Nickname),
//             // Puedes agregar más claims si necesitas información adicional sobre el usuario
//         };

//         var claimsIdentity = new ClaimsIdentity(claims, "CustomAuthentication");

//         var authProperties = new AuthenticationProperties
//         {
//             RedirectUri = "/Inicio" // Ruta a la que se redirigirá después de la autenticación exitosa
//         };

//         var httpContext = _httpContextAccessor.HttpContext;

//         await httpContext.SignInAsync("CustomAuthentication", new ClaimsPrincipal(claimsIdentity), authProperties);

//         // Realiza otras operaciones después de SignInAsync
//         return true;
//     }

//     return false;
//     }

//     public async Task LogoutAsync()
//     {
//         var httpContext = _httpContextAccessor.HttpContext;
//         await httpContext!.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
//     }
// }