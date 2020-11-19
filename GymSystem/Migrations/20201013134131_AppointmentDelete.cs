using Microsoft.EntityFrameworkCore.Migrations;

namespace GymSystem.Migrations
{
    public partial class AppointmentDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Appointment",
                table: "UserTrainings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Appointment",
                table: "UserTrainings",
                nullable: false,
                defaultValue: "");
        }
    }
}
