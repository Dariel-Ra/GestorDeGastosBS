using Microsoft.EntityFrameworkCore;
using GestorDeGastosBS.Data.Models;


namespace GestorDeGastosBS.Data.Context;

public interface IMyDbContext
{
    DbSet<Usuario> Usuarios { get; set; }
    DbSet<Empleado> Empleados { get; set; }
    DbSet<Nomina> Nominas { get; set; }
    DbSet<Producto> Productos { set; get; }
    DbSet<Proveedor> Proveedores { get; set; }
    DbSet<GastosProveedor> GastosProveedores { get; set; }
    DbSet<GastosMercancia> GastosMercancias { get; set; }
    DbSet<GastosMiscelaneo> GastosMiscelaneos { get; set; }
    DbSet<GastosGenerales> GastosGenerales { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

public class MyDbContext : DbContext, IMyDbContext
{
    private readonly IConfiguration config;

    public MyDbContext(IConfiguration _config)
    {
        config = _config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(config.GetConnectionString("CRUD"));
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }

    #region Tablas de mi base de datos
    public DbSet<Usuario> Usuarios { set; get; } = null!;
    public DbSet<Empleado> Empleados { get; set; } = null!;
    public DbSet<Nomina> Nominas { get; set; } = null!;
    public DbSet<Producto> Productos { set; get; } = null!;    
    public DbSet<Proveedor> Proveedores { get; set; } = null!;
    public DbSet<GastosProveedor> GastosProveedores { get; set; } = null!;
    public DbSet<GastosMercancia> GastosMercancias { get; set; } = null!;
    public DbSet<GastosMiscelaneo> GastosMiscelaneos { get; set; } = null!;
    public DbSet<GastosGenerales> GastosGenerales { get; set; } = null!;
    #endregion
}