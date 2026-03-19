using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Professonal.DAL.Migrations
{
    /// <inheritdoc />
    public partial class mm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "MediaItems");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "MediaItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "MediaItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "MediaItems",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
