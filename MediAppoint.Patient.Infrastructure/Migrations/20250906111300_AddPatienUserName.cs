using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediAppoint.Patient.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPatienUserName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Patients");
        }
    }
}
