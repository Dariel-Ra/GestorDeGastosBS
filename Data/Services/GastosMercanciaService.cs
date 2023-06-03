using GestorDeGastosBS.Data.Context;
using GestorDeGastosBS.Data.Response;
using GestorDeGastosBS.Data.Models;
using GestorDeGastosBS.Data.Request;
using GestorDeGastosBS.Data.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace GestorDeGastosBS.Data.Services;

public interface IGastosMercanciaServices
{
    Task<Result<List<GastosMercanciaResponse>>> Consultar(string filtro);
    Task<Result> Crear(GastosMercanciaRequestUpdate request);
    Task<Result> Eliminar(GastosMercanciaRequestUpdate request);
    Task<Result> Modificar(GastosMercanciaRequestUpdate request);
    Task<Result> SoftDeleted(GastosMercanciaRequestUpdate request);
}

public class GastosMercanciaServices : IGastosMercanciaServices
{
    private readonly IMyDbContext dbContext;

    public GastosMercanciaServices(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Result> Crear(GastosMercanciaRequestUpdate request)
    {
        try
        {
            var mercancia = GastosMercancia.Crear(request);
            dbContext.GastosMercancias.Add(mercancia);
            await dbContext.SaveChangesAsync();
            return Result<int>.Success(mercancia.GastosMercanciaId);
        }
        catch (Exception E)
        {

            return Result.Fail(E.Message);
        }
    }
    public async Task<Result> Modificar(GastosMercanciaRequestUpdate request)
    {
        try
        {
            var contacto = await dbContext.GastosMercancias
                .FirstOrDefaultAsync(c => c.GastosMercanciaId == request.GastosMercanciaId);
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
    public async Task<Result> Eliminar(GastosMercanciaRequestUpdate request)
    {
        try
        {
            var contacto = await dbContext.GastosMercancias
                .FirstOrDefaultAsync(c => c.GastosMercanciaId == request.GastosMercanciaId);
            if (contacto == null)
                return Result.Fail("No se encontro el contacto");

            dbContext.GastosMercancias.Remove(contacto);
            await dbContext.SaveChangesAsync();
            return Result.Sucess("Ok");
        }
        catch (Exception E)
        {

            return Result.Fail(E.Message);
        }
    }

    public async Task<Result> SoftDeleted(GastosMercanciaRequestUpdate request)
    {
        try
        {
            var contacto = await dbContext.GastosMercancias
                .FirstOrDefaultAsync(c => c.GastosMercanciaId == request.GastosMercanciaId);
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

    public async Task<Result<List<GastosMercanciaResponse>>> Consultar(string filtro)
    {
        try
        {
            var contactos = await dbContext.GastosMercancias
                .Include(p => p.Mercancia)
                .ThenInclude(p => p.Proveedor)
                .Select(c => c.ToResponse())
                .ToListAsync();
            return Result<List<GastosMercanciaResponse>>.Success(contactos, "Ok");
        }
        catch (Exception E)
        {
            return Result<List<GastosMercanciaResponse>>.Fail(E.Message);
        }
    }
}
