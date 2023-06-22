using GestorDeGastosBS.Data.Models;

namespace GestorDeGastosBS.Data.Context
{
    public class MyDbContextSeeder
    {
        public static async Task Inicializar(MyDbContext dbContext)
        {
            if (!dbContext.Proveedores.Any())
            {
                var ciudades = new List<Proveedor>() { 
                    new Proveedor(){ Nombre = "Xotic Flavors", Direccion = "Calle Comercial #25", Telefono = "809-214-8912", CorreoElectronico = "info@xoticflavors.com", IsDeleted = true},
                    new Proveedor()
                    { 
                        Nombre = "Exotic Imports", 
                        Direccion = "Calle de las Maravillas, 123", 
                        Telefono = "+1 234 567 890", 
                        CorreoElectronico = "info@exoticimports.com", 
                        IsDeleted = true
                    },
                    new Proveedor()
                    {
                        Nombre = "Global Traders",
                        Direccion = "Avenida Internacional, 456",
                        Telefono = "555-123-4567",
                        CorreoElectronico = "info@globaltraders.com",
                        IsDeleted = true
                    },
                    new Proveedor()
                    {
                        Nombre = "Wonderful Goods",
                        Direccion = "Plaza de los Sueños, 789",
                        Telefono = "+1 987 654 3210",
                        CorreoElectronico = "info@wonderfulgoods.com",
                        IsDeleted = true
                    },
                    new Proveedor()
                    {
                        Nombre = "Unique Supplies",
                        Direccion = "Calle de la Fantasía, 987",
                        Telefono = "123-456-7890",
                        CorreoElectronico = "info@uniquesupplies.com",
                        IsDeleted = true
                    },
                    new Proveedor()
                    {
                        Nombre = "Mystical Imports",
                        Direccion = "Ruta de los Misterios, 543",
                        Telefono = "+1 789 012 3456",
                        CorreoElectronico = "info@mysticalimports.com",
                        IsDeleted = true
                    },
                    new Proveedor()
                    {
                        Nombre = "Dreamland Traders",
                        Direccion = "Avenida de los Sueños, 789",
                        Telefono = "555-987-6543",
                        CorreoElectronico = "info@dreamlandtraders.com",
                        IsDeleted = true
                    }
                
                };
                dbContext.Proveedores.AddRange(ciudades);
                await dbContext.SaveChangesAsync();
            }

            if (!dbContext.Productos.Any())
            {
                var mercancias = new List<Producto>() 
                {
                    new Producto()
                    {
                        Nombre = "Llantas Super X",
                        Descripcion = "Llantas todo terreno",
                        Stock = 50,
                        Precio = 500,
                        ProveedorId = 1
                    }
                };
                dbContext.Productos.AddRange(mercancias);
                await dbContext.SaveChangesAsync();
            }

            if (!dbContext.Usuarios.Any())
            {
                var mercancias = new List<Usuario>() 
                {
                    new Usuario()
                    {
                        UserName = "Dariel Rafael",
                        Nickname = "Dariel",
                        Password = "1234.abcd",
                        Role = "Admin",
                        Estado = false
                    },
                    new Usuario()
                    {
                        UserName = "Ramon",
                        Nickname = "Ramon",
                        Password = "abcd.1234",
                        Role = "Admin",
                        Estado = false
                    },
                    new Usuario()
                    {
                        UserName = "Jose M.",
                        Nickname = "Jose",
                        Password = "abcd",
                        Role = "Empleado",
                        Estado = false
                    },
                    new Usuario()
                    {
                        UserName = "Humberto Gil",
                        Nickname = "Humberto",
                        Password = "1234",
                        Role = "User",
                        Estado = false
                    }
                };
                dbContext.Usuarios.AddRange(mercancias);
                await dbContext.SaveChangesAsync();
            }

            
            if (!dbContext.Empleados.Any())
            {
                var mercancias = new List<Empleado>() 
                {
                    new Empleado()
                    {
                        NombreCompleto = "Dariel Rafael",
                        Cargo = "IT",
                        Cedula = "12821565691",
                        Sueldo = 39000,
                        Inactivo = false
                    }
                };
                dbContext.Empleados.AddRange(mercancias);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
