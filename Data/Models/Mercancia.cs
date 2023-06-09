

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GestorDeGastosBS.Data.Request;
using GestorDeGastosBS.Data.Response;
using Microsoft.EntityFrameworkCore;

namespace GestorDeGastosBS.Data.Models;
public class Producto
{
    [Key]
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Descripcion { get;set; } = null!; 
    public int Stock { get; set; }
    [Precision(18, 2)]
    public decimal Precio { get; set; }
    public int ProveedorId { get; set; }
    public virtual Proveedor Proveedor { get; set; } = null!;    
    
    public static Producto Crear(ProductoRequest request)
    {
        return new Producto(){
            Nombre = request.Nombre,
            Descripcion = request.Descripcion,
            Stock = request.Stock,
            Precio = request.Precio,
            ProveedorId = request.ProveedorId
        };
    }
    public bool Mofidicar(ProductoRequest proveedor)
        {
            var cambio = false;
            if(Nombre != proveedor.Nombre)
            {
                Nombre = proveedor.Nombre;
                cambio = true;
            }
            if (Descripcion != proveedor.Descripcion)
            {
                Descripcion = proveedor.Descripcion;
                cambio = true;
            }
            if (Stock != proveedor.Stock)
            {
                Stock = proveedor.Stock;
                cambio = true;
            }
            if (Precio != proveedor.Precio)
            {
                Precio = proveedor.Precio;
                cambio = true;
            }
            if(ProveedorId != proveedor.ProveedorId)
            {
                ProveedorId = proveedor.ProveedorId;
                cambio = true;
            }
            return cambio;
        }

    public ProductoResponse ToResponse()
    {
        return new ProductoResponse (Id, Nombre, Descripcion, Stock, Precio, Proveedor!.ToResponse());
    }
}
public class Empleado
{
    [Key]
    public int EmpleadoId {get; set; }
    public string NombreCompleto { get; set; } = null!;
    public string? Cargo { get; set; }
    public string? Cedula { get; set; }
    [Precision(18, 2)]
    public decimal Sueldo { get; set; }
    public bool Inactivo { get; set; }
    
    public EmpleadoResponse ToResponse()
    => new() 
    {
        EmpleadoId = EmpleadoId,
        NombreCompleto = NombreCompleto, 
        Cargo = Cargo,
        Cedula = Cedula,
        Sueldo = Sueldo,
        Inactivo = Inactivo,
    };
}

public class Nomina
{
    [Key]
    public int NominaId { get; set; }
    public DateTime Fecha { get; set; }
    [Precision(18, 2)]
    public decimal Incentivos { get; set; }
    [Precision(18, 2)]
    public decimal MontoBruto { get; set; }
    [Precision(18, 2)]
    public decimal Deducciones { get; set; }
    [Precision(18, 2)]
    public decimal MontoNeto { get; set; }
    public int EmpleadoId { get; set; }
    public virtual Empleado Empleado { get; set; } = null!;

    public static Nomina Crear(NominaRequest request)
    => new (){ 
             
        NominaId = request.NominaId,
        Fecha = request.Fecha, 
        Incentivos = request.Incentivos,
        MontoBruto = request.MontoBruto,
        Deducciones = request.Deducciones,
        MontoNeto = request.MontoNeto,
        EmpleadoId = request.Empleado.EmpleadoId
    };

    public bool Mofidicar(NominaRequest mercancia)
    {
        var cambio = false;
        if(Fecha != mercancia.Fecha)
        {
            Fecha = mercancia.Fecha;
            cambio = true;
        }
        if(Incentivos != mercancia.Incentivos)
        {
            Incentivos = mercancia.Incentivos;
            cambio = true;
        }
        if (MontoBruto != mercancia.MontoBruto)
        {
            MontoBruto = mercancia.MontoBruto;
            cambio = true;
        }
        if(Deducciones != mercancia.Deducciones)
        {
            Deducciones = mercancia.Deducciones;
            cambio = true;
        }
        if (MontoNeto != mercancia.MontoNeto)
        {
            MontoNeto = mercancia.MontoNeto;
            cambio = true;
        }
        if (EmpleadoId != mercancia.EmpleadoId)
        {
            EmpleadoId = mercancia.EmpleadoId;
            cambio = true;
        }
        return cambio;
    }

    public NominaResponse ToResponse()
    => new() 
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

public class GastosGenerales
{
    [Key]
    public int GastoGeneralesId { get; set; }
    public DateTime Fecha { get; set; }
    public int? Nominaid { get; set; }
    public virtual Nomina Nomina { get; set; } = null!;
    public int? GastosMercanciaId { get; set; }
    public virtual GastosMercancia GastosMercancia { get; set; } = null!;
    public int? GastosProveedorId { get; set; }
    public virtual GastosProveedor GastosProveedor { get; set; } = null!;
    public int? GastosMiscelaneoId { get; set; }
    public virtual GastosMiscelaneo GastoMiscelaneo { get; set; } = null!;
} 

public class GastosMiscelaneo{
    [Key]
    public int GastosMiscelaneoId { get; set; }
    public string Nombre { get; set; } = null!;
    public DateTime Fecha { get; set; }
    public int Cantidad { get; set; }
    [Precision(18, 2)]
    public decimal Precio { get; set; }
    public string Descripcion { get; set; } = null!;
    [NotMapped]
    public decimal MontoTotal => Cantidad * Precio;
    
    public static GastosMiscelaneo Crear(GastosMiscelaneoRequest request)
    => new (){ 
             
        GastosMiscelaneoId = request.GastosMiscelaneoId,
        Nombre = request.Nombre,
        Fecha = request.Fecha, 
        Cantidad = request.Cantidad,
        Precio = request.Precio,
        Descripcion = request.Descripcion
    };

    public bool Mofidicar(GastosMiscelaneoRequest mercancia)
    {
        var cambio = false;
        if(Nombre != mercancia.Nombre)
        {
            Nombre = mercancia.Nombre;
            cambio = true;
        }
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
        if (Precio != mercancia.Precio)
        {
            Precio = mercancia.Precio;
            cambio = true;
        }
        if (Descripcion != mercancia.Descripcion)
        {
            Descripcion = mercancia.Descripcion;
            cambio = true;
        }
        return cambio;
    }

    public GastosMiscelaneoResponse ToResponse()
    => new() 
    {
        GastosMiscelaneoId = GastosMiscelaneoId,
        Nombre = Nombre,
        Fecha = Fecha,
        Cantidad = Cantidad,
        Precio = Precio,
        Descripcion = Descripcion
    };
    
}

public class GastosProveedor{
    [Key]
    public int Id { get; set; }
    public DateTime Fecha { get; set; } 
    public string Descripcion { get; set; } = null!;
    public int Cantidad { get; set; }
    [Precision(18, 2)]
    public decimal Precio { get; set; }
    public int? ProductoId { get; set; }
    [ForeignKey("ProductoId")]
    public virtual Producto Producto { get; set; } = null!;
    public int? ProveedorId { get; set; }
    [ForeignKey("ProveedorId")]
    public virtual Proveedor? Proveedor { get; set; } 
    [NotMapped]
    public decimal MontoTotal => Cantidad * Precio;

    public static GastosProveedor Crear(GastosProveedorRequest request)
    => new (){ 
             
        Id = request.Id,
        Fecha = request.Fecha, 
        Descripcion = request.Descripcion,
        Cantidad = request.Cantidad,
        Precio = request.Precio,
        ProductoId = request.ProductoId,
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
        if (Cantidad != mercancia.Cantidad)
        {
            Cantidad = mercancia.Cantidad;
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

    public GastosProveedorResponse ToResponse()
    => new ()
    {
        Id = Id,
        Fecha = Fecha, 
        Descripcion = Descripcion, 
        Cantidad = Cantidad,
        Precio = Precio, 
        Producto = Producto != null? Producto!.ToResponse():null,
        Proveedor = Proveedor != null? Proveedor!.ToResponse():null
    };
    

}


public class Proveedor
{
    [Key]
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Direccion { get; set; } = null!;
    public string Telefono { get; set; } = null!;
    public string CorreoElectronico { get; set; } = null!;
    public bool IsDeleted { get; set; }

    public static Proveedor Crear(ProveedorRequest request)
    {
        return new Proveedor()
        {
            Nombre = request.Nombre,
            Direccion = request.Direccion,
            Telefono = request.Telefono,
            CorreoElectronico = request.CorreoElectronico,
            IsDeleted = request.IsDeleted
        };
    }

    public bool Mofidicar(ProveedorRequest proveedor)
    {
        var cambio = false;
        if(Nombre != proveedor.Nombre)
        {
            Nombre = proveedor.Nombre;
            cambio = true;
        }
        if (Direccion != proveedor.Direccion)
        {
            Direccion = proveedor.Direccion;
            cambio = true;
        }
        if(Telefono != proveedor.Telefono)
        {
            Telefono = proveedor.Telefono;
            cambio = true;
        }
        if(CorreoElectronico != proveedor.CorreoElectronico)
        {
            CorreoElectronico = proveedor.CorreoElectronico;
            cambio = true;
        }
        if(IsDeleted != proveedor.IsDeleted)
        {
            IsDeleted = proveedor.IsDeleted;
            cambio = true;
        }
        return cambio;
        }
    public ProveedorResponse ToResponse()
    {
        return new ProveedorResponse(Id, Nombre, Direccion, Telefono, CorreoElectronico, IsDeleted);
    } 
}



public class GastosMercancia{
    [Key]
    public int GastosMercanciaId { get; set; }
    [Column(TypeName="Date")]
    public DateTime Fecha { get; set; }
    public int Cantidad { get; set; }
    public decimal MontoTotal { get; set; }
    public string Descripcion { get; set; } = null!;
    public int ProductoId { get; set; }
    public virtual Producto Producto { get; set; } = null!;

    public static GastosMercancia Crear(GastosMercanciaRequest request)
    {
        return new GastosMercancia(){ 
             
            Fecha = request.Fecha,
            Cantidad = request.Cantidad,
            MontoTotal = request.MontoTotal,
            Descripcion = request.Descripcion,
            ProductoId = request.ProductoId 
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

        if (Descripcion != mercancia.Descripcion)
        {
            Descripcion = mercancia.Descripcion;
            cambio = true;
        }
        if(ProductoId != mercancia.ProductoId)
        {
            ProductoId = mercancia.ProductoId;
            cambio = true;
        }
        return cambio;
    }


    public GastosMercanciaResponse ToResponse() 
    => new () 
    {
        GastosMercanciaId = GastosMercanciaId,
        Fecha = Fecha, 
        Cantidad = Cantidad, 
        MontoTotal = MontoTotal, 
        Descripcion = Descripcion, 
        Producto = Producto.ToResponse()
    };
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



