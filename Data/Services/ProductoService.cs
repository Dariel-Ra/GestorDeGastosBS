using GestorDeGastosBS.Data.Context;
using GestorDeGastosBS.Data.Response;
using GestorDeGastosBS.Data.Models;
using GestorDeGastosBS.Data.Request;
using GestorDeGastosBS.Data.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace GestorDeGastosBS.Data.Services;

public interface IProductoServices
{
    Task<Result<List<ProductoResponse>>> Consultar(string filtro);
    Task<Result> Crear(ProductoRequestUpdate request);
    Task<Result> Eliminar(ProductoRequestUpdate request);
    Task<Result> SoftDeleted(ProductoRequestUpdate request);
    Task<Result> Modificar(ProductoRequestUpdate request);
}

public class ProductoServices : IProductoServices
{
    private readonly IMyDbContext dbContext;

    public ProductoServices(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Result> Crear(ProductoRequestUpdate request)
    {
        try
        {
            var mercancia = Producto.Crear(request);
            dbContext.Productos.Add(mercancia);
            await dbContext.SaveChangesAsync();
            return Result<int>.Success(mercancia.Id);
        }
        catch (Exception E)
        {

            return Result.Fail(E.Message);
        }
    }
    public async Task<Result> Modificar(ProductoRequestUpdate request)
    {
        try
        {
            var contacto = await dbContext.Productos
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
    public async Task<Result> Eliminar(ProductoRequestUpdate request)
    {
        try
        {
            var contacto = await dbContext.Productos
                .FirstOrDefaultAsync(c => c.Id == request.Id);
            if (contacto == null)
                return Result.Fail("No se encontro el contacto");

            dbContext.Productos.Remove(contacto);
            await dbContext.SaveChangesAsync();
            return Result.Sucess("Ok");
        }
        catch (Exception E)
        {

            return Result.Fail(E.Message);
        }
    }

    public async Task<Result> SoftDeleted(ProductoRequestUpdate request)
    {
        try
        {
            var contacto = await dbContext.Productos
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

    public async Task<Result<List<ProductoResponse>>> Consultar(string filtro)
    {
        try
        {
            var contactos = await dbContext.Productos
                .Include(p => p.Proveedor)
                .Where(c =>
                    (c.Nombre + " " + c.Descripcion)
                    .ToLower()
                    .Contains(filtro.ToLower()
                    )
                )
                .Select(c => c.ToResponse())
                .ToListAsync();
            return Result<List<ProductoResponse>>.Success(contactos, "Ok");
        }
        catch (Exception E)
        {
            return Result<List<ProductoResponse>>.Fail(E.Message);
        }
    }

    
}
