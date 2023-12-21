using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseModel.Migrations.MsSql
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervations_Books_BookId",
                table: "Rezervations");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezervations_Customers_CustomerId",
                table: "Rezervations");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Rezervations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "Rezervations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervations_Books_BookId",
                table: "Rezervations",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervations_Customers_CustomerId",
                table: "Rezervations",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervations_Books_BookId",
                table: "Rezervations");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezervations_Customers_CustomerId",
                table: "Rezervations");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Rezervations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "Rezervations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervations_Books_BookId",
                table: "Rezervations",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervations_Customers_CustomerId",
                table: "Rezervations",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");
        }
    }
}
