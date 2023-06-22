using GestorDeGastosBS.Data.Context;
using GestorDeGastosBS.Data.Response;
using GestorDeGastosBS.Data.Models;
using GestorDeGastosBS.Data.Request;
using GestorDeGastosBS.Data.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace GestorDeGastosBS.Data.Services;

public interface INominaServices
{
    Task<Result<List<NominaResponse>>> Consultar(string filtro);
    Task<Result> Crear(NominaRequest request);
    Task<Result> Eliminar(NominaRequest request);
    Task<Result> Modificar(NominaRequest request);
    Task<Result> SoftDeleted(NominaRequest request);
}

public class NominaServices : INominaServices
{
    private readonly IMyDbContext dbContext;

    public NominaServices(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Result> Crear(NominaRequest request)
    {
        try
        {
            var mercancia = Nomina.Crear(request);
            dbContext.Nominas.Add(mercancia);
            await dbContext.SaveChangesAsync();
            return Result<int>.Success(mercancia.NominaId);
        }
        catch (Exception E)
        {

            return Result.Fail(E.Message);
        }
    }
    public async Task<Result> Modificar(NominaRequest request)
    {
        try
        {
            var contacto = await dbContext.Nominas
                .FirstOrDefaultAsync(c => c.NominaId == request.NominaId);
            if (contacto == null)
                return Result.Fail("No se encontro el contacto");

            if (contacto.Mofidicar(request))
                await dbContext.SaveChangesAsync();

            return Result.Sucess("Ok");
        }
        catch (Exception E)
        {

            return Result.Fail(E.Message);
        }
    }
    public async Task<Result> Eliminar(NominaRequest request)
    {
        try
        {
            var contacto = await dbContext.Nominas
                .FirstOrDefaultAsync(c => c.NominaId == request.NominaId);
            if (contacto == null)
                return Result.Fail("No se encontro el contacto");

            dbContext.Nominas.Remove(contacto);
            await dbContext.SaveChangesAsync();
            return Result.Sucess("Ok");
        }
        catch (Exception E)
        {

            return Result.Fail(E.Message);
        }
    }

    public async Task<Result> SoftDeleted(NominaRequest request)
    {
        try
        {
            var contacto = await dbContext.Nominas
                .FirstOrDefaultAsync(c => c.NominaId == request.NominaId);
            if (contacto == null)
                return Result.Fail("No se encontro el contacto");

            await dbContext.SaveChangesAsync();
            return Result.Sucess("Ok");
        }
        catch (Exception E)
        {

            return Result.Fail(E.Message);
        }
    }

    public async Task<Result<List<NominaResponse>>> Consultar(string filtro)
    {
        try
        {
            var contactos = await dbContext.Nominas
                .Include(p => p.Empleado)
                .Select(c => c.ToResponse())
                .ToListAsync();
            return Result<List<NominaResponse>>.Success(contactos, "Ok");
        }
        catch (Exception E)
        {
            return Result<List<NominaResponse>>.Fail(E.Message);
        }
    }
}
