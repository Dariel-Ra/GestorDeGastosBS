using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorDeGastosBS.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    EmpleadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.EmpleadoId);
                });

            migrationBuilder.CreateTable(
                name: "GastosMiscelaneos",
                columns: table => new
                {
                    GastosMiscelaneoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GastosMiscelaneos", x => x.GastosMiscelaneoId);
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    ProveedorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.ProveedorId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Nominas",
                columns: table => new
                {
                    Nominaid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpleadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nominas", x => x.Nominaid);
                    table.ForeignKey(
                        name: "FK_Nominas_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GastosProveedores",
                columns: table => new
                {
                    GastosProveedorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "Date", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gastos = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProveedorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GastosProveedores", x => x.GastosProveedorId);
                    table.ForeignKey(
                        name: "FK_GastosProveedores_Proveedores_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedores",
                        principalColumn: "ProveedorId");
                });

            migrationBuilder.CreateTable(
                name: "Mercancias",
                columns: table => new
                {
                    MercanciaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MercanciaNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MercanciaDescripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProveedorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mercancias", x => x.MercanciaId);
                    table.ForeignKey(
                        name: "FK_Mercancias_Proveedores_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedores",
                        principalColumn: "ProveedorId");
                });

            migrationBuilder.CreateTable(
                name: "GastosMercancias",
                columns: table => new
                {
                    GastosMercanciaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "Date", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MercanciaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GastosMercancias", x => x.GastosMercanciaId);
                    table.ForeignKey(
                        name: "FK_GastosMercancias_Mercancias_MercanciaId",
                        column: x => x.MercanciaId,
                        principalTable: "Mercancias",
                        principalColumn: "MercanciaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GastosGenerales",
                columns: table => new
                {
                    GastoGeneralesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nominaid = table.Column<int>(type: "int", nullable: false),
                    GastosMercanciaId = table.Column<int>(type: "int", nullable: false),
                    GastosProveedorId = table.Column<int>(type: "int", nullable: false),
                    GastosMiscelaneoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GastosGenerales", x => x.GastoGeneralesId);
                    table.ForeignKey(
                        name: "FK_GastosGenerales_GastosMercancias_GastosMercanciaId",
                        column: x => x.GastosMercanciaId,
                        principalTable: "GastosMercancias",
                        principalColumn: "GastosMercanciaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GastosGenerales_GastosMiscelaneos_GastosMiscelaneoId",
                        column: x => x.GastosMiscelaneoId,
                        principalTable: "GastosMiscelaneos",
                        principalColumn: "GastosMiscelaneoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GastosGenerales_GastosProveedores_GastosProveedorId",
                        column: x => x.GastosProveedorId,
                        principalTable: "GastosProveedores",
                        principalColumn: "GastosProveedorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GastosGenerales_Nominas_Nominaid",
                        column: x => x.Nominaid,
                        principalTable: "Nominas",
                        principalColumn: "Nominaid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GastosGenerales_GastosMercanciaId",
                table: "GastosGenerales",
                column: "GastosMercanciaId");

            migrationBuilder.CreateIndex(
                name: "IX_GastosGenerales_GastosMiscelaneoId",
                table: "GastosGenerales",
                column: "GastosMiscelaneoId");

            migrationBuilder.CreateIndex(
                name: "IX_GastosGenerales_GastosProveedorId",
                table: "GastosGenerales",
                column: "GastosProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_GastosGenerales_Nominaid",
                table: "GastosGenerales",
                column: "Nominaid");

            migrationBuilder.CreateIndex(
                name: "IX_GastosMercancias_MercanciaId",
                table: "GastosMercancias",
                column: "MercanciaId");

            migrationBuilder.CreateIndex(
                name: "IX_GastosProveedores_ProveedorId",
                table: "GastosProveedores",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Mercancias_ProveedorId",
                table: "Mercancias",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Nominas_EmpleadoId",
                table: "Nominas",
                column: "EmpleadoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GastosGenerales");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "GastosMercancias");

            migrationBuilder.DropTable(
                name: "GastosMiscelaneos");

            migrationBuilder.DropTable(
                name: "GastosProveedores");

            migrationBuilder.DropTable(
                name: "Nominas");

            migrationBuilder.DropTable(
                name: "Mercancias");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Proveedores");
        }
    }
}
