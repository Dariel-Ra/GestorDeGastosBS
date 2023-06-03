

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GestorDeGastosBS.Data.Request;
using GestorDeGastosBS.Data.Response;

namespace GestorDeGastosBS.Data.Models;
public class Mercancia
{
    [Key]
    public int MercanciaId { get; set; }
    public string MercanciaNombre { get; set; } = null!;
    public string MercanciaDescripcion { get;set; } = null!; 
    public decimal Precio { get; set; }
    public int? ProveedorId { get; set; }
    public virtual Proveedor? Proveedor { get; set; }      
    
    public static Mercancia Crear(MercanciaRequest request)
    {
        return new Mercancia(){
            MercanciaNombre = request.MercanciaNombre,
            MercanciaDescripcion = request.MercanciaDescripcion,
            Precio = request.Precio,
            ProveedorId = request.ProveedorId
        };
    }
    public bool Mofidicar(MercanciaRequest mercancia)
        {
            var cambio = false;
            if(MercanciaNombre != mercancia.MercanciaNombre)
            {
                MercanciaNombre = mercancia.MercanciaNombre;
                cambio = true;
            }
            if (MercanciaDescripcion != mercancia.MercanciaDescripcion)
            {
                MercanciaDescripcion = mercancia.MercanciaDescripcion;
                cambio = true;
            }
            if (Precio != mercancia.Precio)
            {
                Precio = mercancia.Precio;
                cambio = true;
            }
            if(ProveedorId != mercancia.ProveedorId)
            {
                ProveedorId = mercancia.ProveedorId;
                cambio = true;
            }
            return cambio;
        }

    public MercanciaResponse ToResponse()
    {
        return new MercanciaResponse (MercanciaId, MercanciaNombre, MercanciaDescripcion, Precio, Proveedor!.ToResponse());
    }
}

public class Empleado
{
    [Key]
    public int EmpleadoId {get; set; }
    public string NombreCompleto { get; set; } = null!;
    public string? Cargo { get; set; }
    public string? Cedula { get; set; }
    public decimal Sueldo { get; set; }
    public bool Estado { get; set; }
}

public class Nomina
{
    [Key]
    public int Nominaid { get; set; }
    public DateTime Fecha { get; set; }
    public decimal Incentivos { get; set; }
    public decimal MontoBruto { get; set; }
    public decimal Deducciones { get; set; }
    public decimal MontoNeto { get; set; }
    public int EmpleadoId { get; set; }
    public virtual Empleado Empleado { get; set; } = null!;
}

public class GastosGenerales
{
    [Key]
    public int GastoGeneralesId { get; set; }
    public DateTime Fecha { get; set; }
    public int Nominaid { get; set; }
    public virtual Nomina Nomina { get; set; } = null!;
    public int GastosMercanciaId { get; set; }
    public virtual GastosMercancia GastosMercancia { get; set; } = null!;
    public int GastosProveedorId { get; set; }
    public virtual GastosProveedor GastosProveedor { get; set; } = null!;
    public int GastosMiscelaneoId { get; set; }
    public virtual GastosMiscelaneo GastoMiscelaneo { get; set; } = null!;
} 

public class GastosMiscelaneo{
    [Key]
    public int GastosMiscelaneoId { get; set; }
    public DateTime Fecha { get; set; }
    public string Nombre { get; set; } = null!;
    public int Cantidad { get; set; }
    public decimal MontoTotal { get; set; }
    public string Descripcion { get; set; } = null!;
    
}

public class GastosProveedor{
    [Key]
    public int GastosProveedorId { get; set; }
    [Column(TypeName="Date")]
    public DateTime Fecha { get; set; }
    public string Descripcion { get; set; } = null!;
    public decimal MontoTotal { get; set; }
    public int? ProveedorId { get; set; }
    public virtual Proveedor? Proveedor { get; set; } 

    public static GastosProveedor Crear(GastosProveedorRequest request)
    => new (){ 
             
        GastosProveedorId = request.GastosProveedorId,
        Fecha = request.Fecha, 
        Descripcion = request.Descripcion,
        MontoTotal = request.MontoTotal,
        ProveedorId = request.ProveedorId 
    };
    

    public bool Mofidicar(GastosProveedorRequest mercancia)
    {
        var cambio = false;
        if(Fecha != mercancia.Fecha)
        {
            Fecha = mercancia.Fecha;
            cambio = true;
        }
        if (Descripcion != mercancia.Descripcion)
        {
            Descripcion = mercancia.Descripcion;
            cambio = true;
        }
        if (MontoTotal != mercancia.MontoTotal)
        {
            MontoTotal = mercancia.MontoTotal;
            cambio = true;
        }
        if(ProveedorId != mercancia.ProveedorId)
        {
            ProveedorId = mercancia.ProveedorId;
            cambio = true;
        }
        return cambio;
    }

    public GastosProveedorResponse ToResponse()
    => new ()
    {
        GastosProveedorId = GastosProveedorId,
        Fecha = Fecha, 
        Descripcion = Descripcion, 
        MontoTotal = MontoTotal, 
        Proveedor = Proveedor != null? Proveedor!.ToResponse():null
    };

}
 

public class GastosMercancia{
    [Key]
    public int GastosMercanciaId { get; set; }
    [Column(TypeName="Date")]
    public DateTime Fecha { get; set; }
    public int Cantidad { get; set; }
    public decimal MontoTotal { get; set; }
    public string Descripcion { get; set; } = null!;
    public int MercanciaId { get; set; }
    public virtual Mercancia Mercancia { get; set; } = null!;

    public static GastosMercancia Crear(GastosMercanciaRequest request)
    {
        return new GastosMercancia(){ 
             
            Fecha = request.Fecha,
            Cantidad = request.Cantidad,
            MontoTotal = request.MontoTotal,
            Descripcion = request.Descripcion,
            MercanciaId = request.MercanciaId 
        };
    }

    public bool Mofidicar(GastosMercanciaRequestUpdate mercancia)
    {
        var cambio = false;
        if(Fecha != mercancia.Fecha)
        {
            Fecha = mercancia.Fecha;
            cambio = true;
        }
        if (Cantidad != mercancia.Cantidad)
        {
            Cantidad = mercancia.Cantidad;
            cambio = true;
        }
        if (MontoTotal != mercancia.MontoTotal)
        {
            MontoTotal = mercancia.MontoTotal;
            cambio = true;
        }
        if (Descripcion != mercancia.Descripcion)
        {
            Descripcion = mercancia.Descripcion;
            cambio = true;
        }
        if(MercanciaId != mercancia.MercanciaId)
        {
            MercanciaId = mercancia.MercanciaId;
            cambio = true;
        }
        return cambio;
    }


    public GastosMercanciaResponse ToResponse()
    {
        return new GastosMercanciaResponse(GastosMercanciaId, Fecha, Cantidad, MontoTotal, Descripcion, Mercancia.ToResponse());
    }
}


public class Proveedor
{
    [Key]
    public int ProveedorId { get; set; }
    public string Nombre { get; set; } = null!;
    public string Direccion { get; set; } = null!;
    public string Telefono { get; set; } = null!;
    public string CorreoElectronico { get; set; } = null!;
    public bool Estado { get; set; }

    public static Proveedor Crear(ProveedorRequest request)
    {
        return new Proveedor()
        {
            Nombre = request.Nombre,
            Direccion = request.Direccion,
            Telefono = request.Telefono,
            CorreoElectronico = request.CorreoElectronico,
            Estado = request.Estado
        };
    }

    public bool Mofidicar(ProveedorRequest mercancia)
    {
        var cambio = false;
        if(Nombre != mercancia.Nombre)
        {
            Nombre = mercancia.Nombre;
            cambio = true;
        }
        if (Direccion != mercancia.Direccion)
        {
            Direccion = mercancia.Direccion;
            cambio = true;
        }
        if(Telefono != mercancia.Telefono)
        {
            Telefono = mercancia.Telefono;
            cambio = true;
        }
        if(CorreoElectronico != mercancia.CorreoElectronico)
        {
            CorreoElectronico = mercancia.CorreoElectronico;
            cambio = true;
        }
        if(Estado != mercancia.Estado)
        {
            Estado = mercancia.Estado;
            cambio = true;
        }
        return cambio;
        }
    public ProveedorResponse ToResponse()
    {
        return new ProveedorResponse(ProveedorId, Nombre, Direccion, Telefono, CorreoElectronico, Estado);
    } 
}

public class Usuario
{
    public Usuario()
    {
        
    }
    [Key]
    public int UsuarioId { get; set; }
    [StringLength(45)]
    public string UserName { get; set; } = null!;
    [StringLength(45)]
    public string Nickname { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Role { get; set; } = null!;
    public bool Estado { get; set; }

    public static Usuario Crear(UsuarioRequest request)
    {
        return new Usuario(){ 
             
            UserName = request.UserName,
            Nickname = request.Nickname, 
            Password = request.Password,
            Role = request.Role,
            Estado = request.Estado
            };
        // return new Usuario(request.UsuarioRolId,request.Name, request.Nickname, request.Password);
    }

    public UsuarioResponse ToResponse()
    {
        return new UsuarioResponse(UsuarioId, UserName, Nickname, Password, Role, Estado);
    }
}



