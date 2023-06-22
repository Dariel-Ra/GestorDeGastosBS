using GestorDeGastosBS.Data.Request;

namespace GestorDeGastosBS.Data.Response;

public class MercanciaResponse
{
    public MercanciaResponse()
    {
    }

    public MercanciaResponse(int mercanciaId, string mercanciaNombre, string mercanciaDescripcion, decimal precio, ProveedorResponse? proveedor)
    {
        MercanciaId = mercanciaId;
        MercanciaNombre = mercanciaNombre;
        MercanciaDescripcion = mercanciaDescripcion;
        Precio = precio;
        Proveedor = proveedor;
    }

    public int MercanciaId { get; set; }
    public string MercanciaNombre { get; set; } = null!;
    public string MercanciaDescripcion { get; set; } = null!;
    public decimal Precio { get; set; }
    public int? ProveedorId { get; set; }
    public virtual ProveedorResponse? Proveedor { get; set; }

    public MercanciaRequestUpdate ToRequest(){
        return new MercanciaRequestUpdate{
            MercanciaId = MercanciaId,
            MercanciaNombre = MercanciaNombre,
            MercanciaDescripcion = MercanciaDescripcion,
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

    public ProveedorResponse(int proveedorId, string nombre, string direccion, string telefono, string correoElectronico, bool estado)
    {
        ProveedorId = proveedorId;
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
        CorreoElectronico = correoElectronico;
        Estado = estado;
    }

    public int ProveedorId { get; set; }
    public string Nombre { get; set; } = null!;
    public string Direccion { get; set; } = null!;
    public string Telefono { get; set; } = null!;
    public string CorreoElectronico { get; set; } = null!;
    public bool Estado { get; set; }

        public ProveedorRequestUpdate ToRequest() {
        return new ProveedorRequestUpdate
        {
            ProveedorId = ProveedorId,
            Nombre = Nombre,
            Telefono = Telefono,
            Direccion = Direccion,
            CorreoElectronico = CorreoElectronico,
            Estado = Estado
            
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
    public decimal MontoTotal { get; set; }
    public string Descripcion { get; set; } = null!;

    public GastosMiscelaneoRequest ToRequest() {
        return new GastosMiscelaneoRequest
        {
            GastosMiscelaneoId = GastosMiscelaneoId,
            Nombre = Nombre,
            Fecha = Fecha,
            Cantidad = Cantidad,
            MontoTotal = MontoTotal,
            Descripcion = Descripcion
        };
    }
    
}

public class GastosProveedorResponse
{
    public GastosProveedorResponse()
    {
    }

    public int GastosProveedorId { get; set; }
    public DateTime Fecha { get; set; }
    public string Descripcion { get; set; } = null!;
    public decimal MontoTotal { get; set; }
    public virtual ProveedorResponse? Proveedor { get; set; } 

    public GastosProveedorRequest ToRequest(){
        return new GastosProveedorRequest
        {
            GastosProveedorId = GastosProveedorId,
            Fecha = Fecha,
            Descripcion = Descripcion,
            ProveedorId = Proveedor!.ProveedorId
        };
    }
}

public class GastosMercanciaResponse
{
    public GastosMercanciaResponse()
    {
    }

    public GastosMercanciaResponse(int gastosMercanciaId, DateTime fecha, int cantidad, decimal montoTotal, string descripcion, MercanciaResponse mercancia)
    {
        GastosMercanciaId = gastosMercanciaId;
        Fecha = fecha;
        Cantidad = cantidad;
        MontoTotal = montoTotal;
        Descripcion = descripcion;
        Mercancia = mercancia;
    }

    public int GastosMercanciaId { get; set; }
    public DateTime Fecha { get; set; }
    public int Cantidad { get; set; }
    public decimal MontoTotal { get; set; }
    public string Descripcion { get; set; } = null!;
    public virtual MercanciaResponse Mercancia { get; set; } = null!;

        public GastosMercanciaRequestUpdate ToRequest(){
        return new GastosMercanciaRequestUpdate
        {
            GastosMercanciaId = GastosMercanciaId,
            Fecha = Fecha,
            Cantidad = Cantidad,
            MontoTotal = MontoTotal,
            Descripcion = Descripcion,
            MercanciaId = Mercancia!.MercanciaId
        };
    }
}
