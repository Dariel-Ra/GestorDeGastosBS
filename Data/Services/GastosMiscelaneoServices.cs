using GestorDeGastosBS.Data.Context;
using GestorDeGastosBS.Data.Response;
using GestorDeGastosBS.Data.Models;
using GestorDeGastosBS.Data.Request;
using GestorDeGastosBS.Data.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace GestorDeGastosBS.Data.Services;

public interface IGastosMiscelaneoServices
{
    Task<Result<List<GastosMiscelaneoResponse>>> Consultar(string filtro);
    Task<Result> Crear(GastosMiscelaneoRequest request);
    Task<Result> Eliminar(GastosMiscelaneoRequest request);
    Task<Result> SoftDeleted(GastosMiscelaneoRequest request);
    Task<Result> Modificar(GastosMiscelaneoRequest request);
}

public class GastosMiscelaneoServices : IGastosMiscelaneoServices
{
    private readonly IMyDbContext dbContext;

    public GastosMiscelaneoServices(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Result> Crear(GastosMiscelaneoRequest request)
    {
        try
        {
            var mercancia = GastosMiscelaneo.Crear(request);
            dbContext.GastosMiscelaneos.Add(mercancia);
            await dbContext.SaveChangesAsync();
            return Result<int>.Success(mercancia.GastosMiscelaneoId);
        }
        catch (Exception E)
        {

            return Result.Fail(E.Message);
        }
    }
    public async Task<Result> Modificar(GastosMiscelaneoRequest request)
    {
        try
        {
            var contacto = await dbContext.GastosMiscelaneos
                .FirstOrDefaultAsync(c => c.GastosMiscelaneoId == request.GastosMiscelaneoId);
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
    public async Task<Result> Eliminar(GastosMiscelaneoRequest request)
    {
        try
        {
            var contacto = await dbContext.GastosMiscelaneos
                .FirstOrDefaultAsync(c => c.GastosMiscelaneoId == request.GastosMiscelaneoId);
            if (contacto == null)
                return Result.Fail("No se encontro el contacto");

            dbContext.GastosMiscelaneos.Remove(contacto);
            await dbContext.SaveChangesAsync();
            return Result.Sucess("Ok");
        }
        catch (Exception E)
        {

            return Result.Fail(E.Message);
        }
    }

    public async Task<Result> SoftDeleted(GastosMiscelaneoRequest request)
    {
        try
        {
            var contacto = await dbContext.GastosMiscelaneos
                .FirstOrDefaultAsync(c => c.GastosMiscelaneoId == request.GastosMiscelaneoId);
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

    public async Task<Result<List<GastosMiscelaneoResponse>>> Consultar(string filtro)
    {
        try
        {
            var contactos = await dbContext.GastosMiscelaneos
                .Select(c => c.ToResponse())
                .ToListAsync();
            return Result<List<GastosMiscelaneoResponse>>.Success(contactos, "Ok");
        }
        catch (Exception E)
        {
            return Result<List<GastosMiscelaneoResponse>>.Fail(E.Message);
        }
    }

    
}
