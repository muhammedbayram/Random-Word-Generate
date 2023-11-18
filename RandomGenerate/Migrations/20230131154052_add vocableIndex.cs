using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RandomGenerate.Migrations
{
    public partial class addvocableIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VocableIndex",
                table: "Words",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VocableIndex",
                table: "Words");
        }
    }
}
