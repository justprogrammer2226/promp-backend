using Microsoft.EntityFrameworkCore.Migrations;

namespace Promp.DAL.Migrations
{
    public partial class AddPkForToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsValid",
                table: "PromApiTokens");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsValid",
                table: "PromApiTokens",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
