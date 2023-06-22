using GestorDeGastosBS.Data.Context;
using GestorDeGastosBS.Data.Response;
using GestorDeGastosBS.Data.Models;
using GestorDeGastosBS.Data.Request;
using GestorDeGastosBS.Data.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace GestorDeGastosBS.Data.Services;

public interface IEmpleadoServices
{
    Task<Result<List<EmpleadoResponse>>> Consultar(string filtro);
}

public class EmpleadoServices : IEmpleadoServices
{
    private readonly IMyDbContext dbContext;

    public EmpleadoServices(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Result<List<EmpleadoResponse>>> Consultar(string filtro)
    {
        try
        {
            var contactos = await dbContext.Empleados
                .Select(c => c.ToResponse())
                .ToListAsync();
            return Result<List<EmpleadoResponse>>.Success(contactos, "Ok");
        }
        catch (Exception E)
        {
            return Result<List<EmpleadoResponse>>.Fail(E.Message);
        }
    }
}
