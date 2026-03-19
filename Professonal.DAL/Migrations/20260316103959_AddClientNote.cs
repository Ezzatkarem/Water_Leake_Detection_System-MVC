using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Professonal.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddClientNote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientNote",
                table: "LaekRequests",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientNote",
                table: "LaekRequests");
        }
    }
}
