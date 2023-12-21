using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseModel.Migrations.MsSql
{
    /// <inheritdoc />
    public partial class Book2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PageNumber",
                table: "Books",
                newName: "BookPageNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookPageNumber",
                table: "Books",
                newName: "PageNumber");
        }
    }
}
