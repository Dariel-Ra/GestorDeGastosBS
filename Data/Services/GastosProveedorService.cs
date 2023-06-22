using GestorDeGastosBS.Data.Context;
using GestorDeGastosBS.Data.Response;
using GestorDeGastosBS.Data.Models;
using GestorDeGastosBS.Data.Request;
using GestorDeGastosBS.Data.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace GestorDeGastosBS.Data.Services;

public interface IGastosProveedorServices
{
    Task<Result<List<GastosProveedorResponse>>> Consultar(string filtro);
    Task<Result> Crear(GastosProveedorRequest request);
    Task<Result> Eliminar(GastosProveedorRequest request);
    Task<Result> Modificar(GastosProveedorRequest request);
    Task<Result> SoftDeleted(GastosProveedorRequest request);
}

public class GastosProveedorServices : IGastosProveedorServices
{
    private readonly IMyDbContext dbContext;

    public GastosProveedorServices(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Result> Crear(GastosProveedorRequest request)
    {
        try
        {
            var mercancia = GastosProveedor.Crear(request);
            dbContext.GastosProveedores.Add(mercancia);
            await dbContext.SaveChangesAsync();
            return Result<int>.Success(mercancia.Id);
        }
        catch (Exception E)
        {

            return Result.Fail(E.Message);
        }
    }
    public async Task<Result> Modificar(GastosProveedorRequest request)
    {
        try
        {
            var contacto = await dbContext.GastosProveedores
                .FirstOrDefaultAsync(c => c.Id == request.Id);
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
    public async Task<Result> Eliminar(GastosProveedorRequest request)
    {
        try
        {
            var contacto = await dbContext.GastosProveedores
                .FirstOrDefaultAsync(c => c.Id == request.Id);
            if (contacto == null)
                return Result.Fail("No se encontro el contacto");

            dbContext.GastosProveedores.Remove(contacto);
            await dbContext.SaveChangesAsync();
            return Result.Sucess("Ok");
        }
        catch (Exception E)
        {

            return Result.Fail(E.Message);
        }
    }

    public async Task<Result> SoftDeleted(GastosProveedorRequest request)
    {
        try
        {
            var contacto = await dbContext.GastosProveedores
                .FirstOrDefaultAsync(c => c.Id == request.Id);
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

    public async Task<Result<List<GastosProveedorResponse>>> Consultar(string filtro)
    {
        try
        {
            var contactos = await dbContext.GastosProveedores
                .Include(p => p.Proveedor)
                .Include(p => p.Producto)
                .ThenInclude(p => p.Proveedor)
                .Select(c => c.ToResponse())
                .ToListAsync();
            return Result<List<GastosProveedorResponse>>.Success(contactos, "Ok");
        }
        catch (Exception E)
        {
            return Result<List<GastosProveedorResponse>>.Fail(E.Message);
        }
    }
}
