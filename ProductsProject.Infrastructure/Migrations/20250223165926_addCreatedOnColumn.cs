using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addCreatedOnColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "ProductCategories",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "ProductCategories");
        }
    }
}
