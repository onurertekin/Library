using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseModel.Migrations.MsSql
{
    /// <inheritdoc />
    public partial class Book3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookPageNumber",
                table: "Books",
                newName: "PageCount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PageCount",
                table: "Books",
                newName: "BookPageNumber");
        }
    }
}
