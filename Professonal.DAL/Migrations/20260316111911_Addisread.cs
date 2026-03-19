using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Professonal.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Addisread : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isRead",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isRead",
                table: "Comments");
        }
    }
}
