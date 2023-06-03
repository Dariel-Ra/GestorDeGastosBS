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
                    new Proveedor(){ Nombre = "Xotic Flavors", Direccion = "Calle Comercial #25", Telefono = "809-214-8912", CorreoElectronico = "info@xoticflavors.com", Estado = true},
                    new Proveedor()
                    { 
                        Nombre = "Exotic Imports", 
                        Direccion = "Calle de las Maravillas, 123", 
                        Telefono = "+1 234 567 890", 
                        CorreoElectronico = "info@exoticimports.com", 
                        Estado = true
                    },
                    new Proveedor()
                    {
                        Nombre = "Global Traders",
                        Direccion = "Avenida Internacional, 456",
                        Telefono = "555-123-4567",
                        CorreoElectronico = "info@globaltraders.com",
                        Estado = true
                    },
                    new Proveedor()
                    {
                        Nombre = "Wonderful Goods",
                        Direccion = "Plaza de los Sueños, 789",
                        Telefono = "+1 987 654 3210",
                        CorreoElectronico = "info@wonderfulgoods.com",
                        Estado = true
                    },
                    new Proveedor()
                    {
                        Nombre = "Unique Supplies",
                        Direccion = "Calle de la Fantasía, 987",
                        Telefono = "123-456-7890",
                        CorreoElectronico = "info@uniquesupplies.com",
                        Estado = true
                    },
                    new Proveedor()
                    {
                        Nombre = "Mystical Imports",
                        Direccion = "Ruta de los Misterios, 543",
                        Telefono = "+1 789 012 3456",
                        CorreoElectronico = "info@mysticalimports.com",
                        Estado = true
                    },
                    new Proveedor()
                    {
                        Nombre = "Dreamland Traders",
                        Direccion = "Avenida de los Sueños, 789",
                        Telefono = "555-987-6543",
                        CorreoElectronico = "info@dreamlandtraders.com",
                        Estado = true
                    }
                
                };
                dbContext.Proveedores.AddRange(ciudades);
                await dbContext.SaveChangesAsync();
            }

            if (!dbContext.Mercancias.Any())
            {
                var mercancias = new List<Mercancia>() 
                {
                    new Mercancia()
                    {
                        MercanciaNombre = "Llantas Super X",
                        MercanciaDescripcion = "Llantas todo terreno",
                        Precio = 500,
                        ProveedorId = 1
                    }
                };
                dbContext.Mercancias.AddRange(mercancias);
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
                        Estado = true
                    }
                };
                dbContext.Usuarios.AddRange(mercancias);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
