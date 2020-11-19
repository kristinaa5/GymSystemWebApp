using Microsoft.EntityFrameworkCore.Migrations;

namespace GymSystem.Migrations
{
    public partial class TrainingModelChange2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "free",
                table: "Trainings",
                newName: "Free");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Free",
                table: "Trainings",
                newName: "free");
        }
    }
}
