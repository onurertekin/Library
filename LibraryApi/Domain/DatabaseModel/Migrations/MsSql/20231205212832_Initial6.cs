using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseModel.Migrations.MsSql
{
    /// <inheritdoc />
    public partial class Initial6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Authors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Authors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Authors",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Authors");
        }
    }
}
