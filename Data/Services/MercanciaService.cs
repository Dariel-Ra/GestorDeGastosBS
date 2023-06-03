using GestorDeGastosBS.Data.Context;
using GestorDeGastosBS.Data.Response;
using GestorDeGastosBS.Data.Models;
using GestorDeGastosBS.Data.Request;
using GestorDeGastosBS.Data.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace GestorDeGastosBS.Data.Services;

public interface IMercanciaServices
{
    Task<Result<List<MercanciaResponse>>> Consultar(string filtro);
    Task<Result> Crear(MercanciaRequestUpdate request);
    Task<Result> Eliminar(MercanciaRequestUpdate request);
    Task<Result> SoftDeleted(MercanciaRequestUpdate request);
    Task<Result> Modificar(MercanciaRequestUpdate request);
}

public class MercanciaServices : IMercanciaServices
{
    private readonly IMyDbContext dbContext;

    public MercanciaServices(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Result> Crear(MercanciaRequestUpdate request)
    {
        try
        {
            var mercancia = Mercancia.Crear(request);
            dbContext.Mercancias.Add(mercancia);
            await dbContext.SaveChangesAsync();
            return Result<int>.Success(mercancia.MercanciaId);
        }
        catch (Exception E)
        {

            return Result.Fail(E.Message);
        }
    }
    public async Task<Result> Modificar(MercanciaRequestUpdate request)
    {
        try
        {
            var contacto = await dbContext.Mercancias
                .FirstOrDefaultAsync(c => c.MercanciaId == request.MercanciaId);
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
    public async Task<Result> Eliminar(MercanciaRequestUpdate request)
    {
        try
        {
            var contacto = await dbContext.Mercancias
                .FirstOrDefaultAsync(c => c.MercanciaId == request.MercanciaId);
            if (contacto == null)
                return Result.Fail("No se encontro el contacto");

            dbContext.Mercancias.Remove(contacto);
            await dbContext.SaveChangesAsync();
            return Result.Sucess("Ok");
        }
        catch (Exception E)
        {

            return Result.Fail(E.Message);
        }
    }

    public async Task<Result> SoftDeleted(MercanciaRequestUpdate request)
    {
        try
        {
            var contacto = await dbContext.Mercancias
                .FirstOrDefaultAsync(c => c.MercanciaId == request.ProveedorId);
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

    public async Task<Result<List<MercanciaResponse>>> Consultar(string filtro)
    {
        try
        {
            var contactos = await dbContext.Mercancias
                .Include(p => p.Proveedor)
                .Where(c =>
                    (c.MercanciaNombre + " " + c.MercanciaDescripcion)
                    .ToLower()
                    .Contains(filtro.ToLower()
                    )
                )
                .Select(c => c.ToResponse())
                .ToListAsync();
            return Result<List<MercanciaResponse>>.Success(contactos, "Ok");
        }
        catch (Exception E)
        {
            return Result<List<MercanciaResponse>>.Fail(E.Message);
        }
    }
}
