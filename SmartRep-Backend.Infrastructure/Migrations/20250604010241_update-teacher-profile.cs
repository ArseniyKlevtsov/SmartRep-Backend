using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartRep_Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateteacherprofile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "StatusConfirmed",
                table: "TeacherProfiles",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusConfirmed",
                table: "TeacherProfiles");
        }
    }
}
