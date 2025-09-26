using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudApi.Migrations;

/// <inheritdoc />
public partial class Create_table_order : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "order",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                OrderDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                Total = table.Column<decimal>(type: "DECIMAL(16,2)", nullable: false),
                CustomerId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_order", x => x.Id);
                table.ForeignKey(
                    name: "FK_order_customer_CustomerId",
                    column: x => x.CustomerId,
                    principalTable: "customer",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_order_CustomerId",
            table: "order",
            column: "CustomerId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "order");
    }
}
