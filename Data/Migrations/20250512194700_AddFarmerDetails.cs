using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PROG7311_POE_PART_2.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFarmerDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Farmers",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Farmers",
                newName: "PhoneNumber");

            migrationBuilder.AddColumn<string>(
                name: "FarmAddress",
                table: "Farmers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FarmType",
                table: "Farmers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Farmers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FarmAddress",
                table: "Farmers");

            migrationBuilder.DropColumn(
                name: "FarmType",
                table: "Farmers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Farmers");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Farmers",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Farmers",
                newName: "FullName");
        }
    }
}
