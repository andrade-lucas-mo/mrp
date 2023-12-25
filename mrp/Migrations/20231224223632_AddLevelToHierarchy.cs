using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mrp.Migrations
{
    public partial class AddLevelToHierarchy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Hierarchies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "Hierarchies");
        }
    }
}
