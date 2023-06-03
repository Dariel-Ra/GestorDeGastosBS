using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorDeGastosBS.Migrations
{
    /// <inheritdoc />
    public partial class DBFixed1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Gastos",
                table: "GastosProveedores",
                newName: "MontoTotal");

            migrationBuilder.AddColumn<decimal>(
                name: "Deducciones",
                table: "Nominas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "Nominas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Incentivos",
                table: "Nominas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MontoBruto",
                table: "Nominas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MontoNeto",
                table: "Nominas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MontoTotal",
                table: "GastosMiscelaneos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MontoTotal",
                table: "GastosMercancias",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Cargo",
                table: "Empleados",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cedula",
                table: "Empleados",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Sueldo",
                table: "Empleados",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deducciones",
                table: "Nominas");

            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Nominas");

            migrationBuilder.DropColumn(
                name: "Incentivos",
                table: "Nominas");

            migrationBuilder.DropColumn(
                name: "MontoBruto",
                table: "Nominas");

            migrationBuilder.DropColumn(
                name: "MontoNeto",
                table: "Nominas");

            migrationBuilder.DropColumn(
                name: "MontoTotal",
                table: "GastosMiscelaneos");

            migrationBuilder.DropColumn(
                name: "MontoTotal",
                table: "GastosMercancias");

            migrationBuilder.DropColumn(
                name: "Cargo",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "Cedula",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "Sueldo",
                table: "Empleados");

            migrationBuilder.RenameColumn(
                name: "MontoTotal",
                table: "GastosProveedores",
                newName: "Gastos");
        }
    }
}
