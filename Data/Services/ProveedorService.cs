using GestorDeGastosBS.Data.Context;
using GestorDeGastosBS.Data.Response;
using GestorDeGastosBS.Data.Models;
using GestorDeGastosBS.Data.Request;
using GestorDeGastosBS.Data.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace GestorDeGastosBS.Data.Services;

public interface IProveedorServices
{
    Task<Result<List<ProveedorResponse>>> Consultar(string filtro);
    Task<Result> Crear(ProveedorRequestUpdate request);
    Task<Result> Eliminar(ProveedorRequestUpdate request);
    Task<Result> SoftDeleted(ProveedorRequestUpdate request);
    Task<Result> Modificar(ProveedorRequestUpdate request);
}

public class ProveedorServices : IProveedorServices
{
    private readonly IMyDbContext dbContext;

    public ProveedorServices(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Result> Crear(ProveedorRequestUpdate request)
    {
        try
        {
            var mercancia = Proveedor.Crear(request);
            dbContext.Proveedores.Add(mercancia);
            await dbContext.SaveChangesAsync();
            return Result<int>.Success(mercancia.ProveedorId);
        }
        catch (Exception E)
        {

            return Result<int>.Fail(E.Message);
        }
    }
    public async Task<Result> Modificar(ProveedorRequestUpdate request)
    {
        try
        {
            var contacto = await dbContext.Proveedores
                .FirstOrDefaultAsync(c => c.ProveedorId == request.ProveedorId);
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
    public async Task<Result> Eliminar(ProveedorRequestUpdate request)
    {
        try
        {
            var contacto = await dbContext.Proveedores
                .FirstOrDefaultAsync(c => c.ProveedorId == request.ProveedorId);
            if (contacto == null)
                return Result.Fail("No se encontro el contacto");

            dbContext.Proveedores.Remove(contacto);
            await dbContext.SaveChangesAsync();
            return Result.Sucess("Ok");
        }
        catch (Exception E)
        {

            return Result.Fail(E.Message);
        }
    }

    public async Task<Result> SoftDeleted(ProveedorRequestUpdate request)
    {
        try
        {
            var contacto = await dbContext.Proveedores
                .FirstOrDefaultAsync(c => c.ProveedorId == request.ProveedorId);
            if (contacto == null)
                return Result.Fail("No se encontro el contacto");
            
            if (contacto.Estado == true)
            {
                contacto.Estado = false;
            }
            else if (contacto.Estado == false)
            {
                contacto.Estado = true;
            }
            await dbContext.SaveChangesAsync();
            return Result.Sucess("Ok");
        }
        catch (Exception E)
        {

            return Result.Fail(E.Message);
        }
    }


    public async Task<Result<List<ProveedorResponse>>> Consultar(string filtro)
    {
        try
        {
            var contactos = await dbContext.Proveedores
                .Where(c =>
                    (c.Nombre + " " + c.Direccion + " " + c.Telefono + " " + c.CorreoElectronico + " " + c.Estado)
                    .ToLower()
                    .Contains(filtro.ToLower()
                    )
                )
                .Select(c => c.ToResponse())
                .ToListAsync();
            return Result<List<ProveedorResponse>>.Success(contactos, "Ok");
        }
        catch (Exception E)
        {
            return Result<List<ProveedorResponse>>.Fail(E.Message);
        }
    }

    // public async Task<Result<List<ProveedorResponse>>> ConsultarSoftDeleted(string filtro)
    // {
    //     try
    //     {
    //         var contactos = await dbContext.Proveedores
    //             .Where(c => c.Estado == false)
    //             .Select(c => c.ToResponse())
    //             .ToListAsync();
    //         return Result<List<ProveedorResponse>>.Success(contactos, "Ok");
    //     }
    //     catch (Exception E)
    //     {
    //         return Result<List<ProveedorResponse>>.Fail(E.Message);
    //     }
    // }
}
