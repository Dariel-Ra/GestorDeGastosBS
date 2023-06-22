using System.ComponentModel.DataAnnotations.Schema;
using GestorDeGastosBS.Data.Request;

namespace GestorDeGastosBS.Data.Response;

public class ProductoResponse
{
    public ProductoResponse()
    {
    }

    public ProductoResponse(int id, string nombre, string descripcion, int stock, decimal precio, ProveedorResponse proveedor)
    {
        Id = id;
        Nombre = nombre;
        Descripcion = descripcion;
        Stock = stock;
        Precio = precio;
        Proveedor = proveedor;
    }

    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Descripcion { get; set; } = null!;
    public int Stock { get; set; }
    public decimal Precio { get; set; }
    public int ProveedorId { get; set; }
    public virtual ProveedorResponse Proveedor { get; set; } = null!;

    public ProductoRequestUpdate ToRequest(){
        return new ProductoRequestUpdate{
            Id = Id,
            Nombre = Nombre,
            Descripcion = Descripcion,
            Stock = Stock,
            Precio = Precio,
            ProveedorId = ProveedorId
        };
    }
}

public class ProveedorResponse
{
    public ProveedorResponse()
    {
    }

    public ProveedorResponse(int id, string nombre, string direccion, string telefono, string correoElectronico, bool isDeleted)
    {
        Id = id;
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
        CorreoElectronico = correoElectronico;
        IsDeleted = isDeleted;
    }

    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Direccion { get; set; } = null!;
    public string Telefono { get; set; } = null!;
    public string CorreoElectronico { get; set; } = null!;
    public bool IsDeleted { get; set; }

        public ProveedorRequestUpdate ToRequest() {
        return new ProveedorRequestUpdate
        {
            Id = Id,
            Nombre = Nombre,
            Telefono = Telefono,
            Direccion = Direccion,
            CorreoElectronico = CorreoElectronico,
            IsDeleted = IsDeleted
            
        };
    }
}

public class EmpleadoResponse
{
    public int EmpleadoId {get; set; }
    public string NombreCompleto { get; set; } = null!;
    public string? Cargo { get; set; }
    public string? Cedula { get; set; }
    public decimal Sueldo { get; set; }
    public bool Inactivo { get; set; }

    public EmpleadoRequest ToRequest(){
        return new EmpleadoRequest
        {
            EmpleadoId = EmpleadoId,
            NombreCompleto = NombreCompleto, 
            Cargo = Cargo,
            Cedula = Cedula,
            Sueldo = Sueldo,
            Inactivo = Inactivo,
        };
    }
}

public class NominaResponse
{
    public int NominaId { get; set; }
    public DateTime Fecha { get; set; }
    public decimal Incentivos { get; set; }
    public decimal MontoBruto { get; set; }
    public decimal Deducciones { get; set; }
    public decimal MontoNeto { get; set; }
    public int EmpleadoId { get; set; }
    public virtual EmpleadoResponse Empleado { get; set; } = null!;

    public NominaRequest ToRequest(){
        return new NominaRequest
        {
            NominaId = NominaId,
            Fecha = Fecha, 
            Incentivos = Incentivos,
            MontoBruto = MontoBruto,
            Deducciones = Deducciones,
            MontoNeto = MontoNeto,
            EmpleadoId = Empleado.EmpleadoId
        };
    }
}

public class GastoGeneralesResponse
{
    public int GastoGeneralesId { get; set; }
    public DateTime Fecha { get; set; }
    public NominaResponse Nomina { get; set; } = null!;
    public GastosMercanciaResponse GastoMercancia { get; set; } = null!;
    public GastosProveedorResponse GastoProveedor { get; set; } = null!;
    public GastosMiscelaneoResponse GastosMiscelaneo { get; set; } = null!;
}

public class GastosMiscelaneoResponse
{
    public int GastosMiscelaneoId { get; set; }
    public string Nombre { get; set; } = null!;
    public DateTime Fecha { get; set; }
    public int Cantidad { get; set; }
    public decimal Precio { get; set; }
    public string Descripcion { get; set; } = null!;
    [NotMapped]
    public decimal MontoTotal => Cantidad * Precio;

    public GastosMiscelaneoRequest ToRequest() {
        return new GastosMiscelaneoRequest
        {
            GastosMiscelaneoId = GastosMiscelaneoId,
            Nombre = Nombre,
            Fecha = Fecha,
            Cantidad = Cantidad,
            Descripcion = Descripcion
        };
    }
    
}

public class GastosProveedorResponse
{
    public GastosProveedorResponse()
    {
    }

    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public string Descripcion { get; set; } = null!;
    public int Cantidad { get; set; }
    public decimal Precio { get; set; }
    public virtual ProductoResponse? Producto { get; set; }
    public virtual ProveedorResponse? Proveedor { get; set; }
    [NotMapped]
    public decimal MontoTotal => Cantidad * Precio;

    public GastosProveedorRequest ToRequest(){
        return new GastosProveedorRequest
        {
            Id = Id,
            Fecha = Fecha,
            Descripcion = Descripcion,
            Cantidad = Cantidad,
            Precio = Precio,
            ProductoId = Producto!.Id,
            ProveedorId = Proveedor!.Id
        };
    }
}

public class GastosMercanciaResponse
{
    public GastosMercanciaResponse()
    {
    }

    public GastosMercanciaResponse(int gastosMercanciaId, DateTime fecha, int cantidad, decimal montoTotal, string descripcion, ProductoResponse producto)
    {
        GastosMercanciaId = gastosMercanciaId;
        Fecha = fecha;
        Cantidad = cantidad;
        MontoTotal = montoTotal;
        Descripcion = descripcion;
        Producto = producto;
    }

    public int GastosMercanciaId { get; set; }
    public DateTime Fecha { get; set; }
    public int Cantidad { get; set; }
    public decimal MontoTotal { get; set; }
    public string Descripcion { get; set; } = null!;
    public virtual ProductoResponse Producto { get; set; } = null!;

        public GastosMercanciaRequestUpdate ToRequest(){
        return new GastosMercanciaRequestUpdate
        {
            GastosMercanciaId = GastosMercanciaId,
            Fecha = Fecha,
            Cantidad = Cantidad,
            MontoTotal = MontoTotal,
            Descripcion = Descripcion,
            ProductoId = Producto!.Id
        };
    }
}
