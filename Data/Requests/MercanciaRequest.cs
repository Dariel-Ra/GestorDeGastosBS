namespace GestorDeGastosBS.Data.Requests;

public class MercanciaRequest
{
    public string MercanciaNombre { get; set; } = null!;
    public string MercanciaDescripcion { get;set; } = null!; 
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
    
    public string NombreCompleto { get; set; } = null!;
    public bool Estado { get; set; }

}

public class EmpleadoRequestUpdate : EmpleadoRequest
{
    public int EmpleadoId { get; set; }
}

public class NominaRequest{
    public int Nominaid { get; set; }
    public int EmpleadoId { get; set; }
}

public class GastoGeneralesRequest{
    public int GastoGeneralesId { get; set; }
    public DateTime Fecha { get; set; }
    public int Nominaid { get; set; }
    public int GastosMercanciaId { get; set; }
    public int GastosProveedorId { get; set; }
    public int GastosMiscelaneoId { get; set; }
} 

public class GastosMiscelaneoRequest{
    public int GastosMiscelaneoId { get; set; }
    public DateTime Fecha { get; set; }
    public string Nombre { get; set; } = null!;
    public string Descricción { get; set; } = null!;
    public int Cantidad { get; set; }
}

public class GastosProveedorRequest{
    public int GastosProveedorId { get; set; }
    public DateTime Fecha { get; set; }
    public string Descricción { get; set; } = null!;
    public decimal Gastos { get; set; }

}

public class GastosMercanciaRequest{
    public DateTime Fecha { get; set; }
    public int Cantidad { get; set; }
    public string Descricción { get; set; } = null!;
    public int MercanciaId { get; set; }
}
public class GastosMercanciaRequestUpdate : GastosMercanciaRequest
{
    public int GastosMercanciaId { get; set; }
}
