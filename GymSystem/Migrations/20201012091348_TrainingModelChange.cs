using Microsoft.EntityFrameworkCore.Migrations;

namespace GymSystem.Migrations
{
    public partial class TrainingModelChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "free",
                table: "Trainings",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "free",
                table: "Trainings");
        }
    }
}
