using Microsoft.EntityFrameworkCore.Migrations;

namespace GymSystem.Migrations
{
    public partial class UserTrainingModelChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Appointment",
                table: "UserTrainings",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Appointment",
                table: "UserTrainings");
        }
    }
}
