namespace GestorDeGastosBS.Data.Request;

public class MercanciaRequest
{
    public string MercanciaNombre { get; set; } = null!;
    public string MercanciaDescripcion { get;set; } = null!; 
    public decimal Precio { get; set; }
    public int? ProveedorId { get; set; }
}
public class MercanciaRequestUpdate : MercanciaRequest
{
    public int MercanciaId { get; set; }
}

public class ProveedorRequest
{
    public string Nombre { get; set; } = null!;
    public string Direccion { get; set; } = null!;
    public string Telefono { get; set; } = null!;
    public string CorreoElectronico { get; set; } = null!;
    public bool Estado { get; set; }
}
public class ProveedorRequestUpdate : ProveedorRequest
{
    public int ProveedorId { get; set; }
}

public class EmpleadoRequest{
    public int EmpleadoId {get; set; }
    public string NombreCompleto { get; set; } = null!;
    public string? Cargo { get; set; }
    public string? Cedula { get; set; }
    public decimal Sueldo { get; set; }
    public bool Inactivo { get; set; }
}


public class NominaRequest{
    public int NominaId { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Now;
    public decimal Incentivos { get; set; }
    public decimal MontoBruto { get; set; }
    public decimal Deducciones { get; set; }
    public decimal MontoNeto { get; set; }
    public int EmpleadoId { get; set; }
    public virtual EmpleadoRequest Empleado { get; set; } = null!;
}

public class GastoGeneralesRequest{
    public int GastoGeneralesId { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Now;
    public int Nominaid { get; set; }
    public int GastosMercanciaId { get; set; }
    public int GastosProveedorId { get; set; }
    public int GastosMiscelaneoId { get; set; }
} 

public class GastosMiscelaneoRequest{
    public int GastosMiscelaneoId { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Now;
    public string Nombre { get; set; } = null!;
    public int Cantidad { get; set; }
    public decimal MontoTotal { get; set; }
    public string Descripcion { get; set; } = null!;
}

public class GastosProveedorRequest{
    public int GastosProveedorId { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Now;
    public string Descripcion { get; set; } = null!;
    public decimal MontoTotal { get; set; }
    public int? ProveedorId { get; set; }

}

public class GastosMercanciaRequest{
    public DateTime Fecha { get; set; } = DateTime.Now;
    public int Cantidad { get; set; }
    public decimal MontoTotal { get; set; }
    public string Descripcion { get; set; } = null!;
    public int MercanciaId { get; set; }
}
public class GastosMercanciaRequestUpdate : GastosMercanciaRequest
{
    public int GastosMercanciaId { get; set; }
}


