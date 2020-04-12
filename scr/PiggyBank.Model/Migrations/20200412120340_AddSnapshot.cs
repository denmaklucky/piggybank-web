using Microsoft.EntityFrameworkCore.Migrations;

namespace PiggyBank.Model.Migrations
{
    public partial class AddSnapshot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Shapshot",
                table: "Operations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Shapshot",
                table: "Operations");
        }
    }
}
