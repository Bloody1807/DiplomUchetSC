using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiplomUchetSC.Migrations
{
    /// <inheritdoc />
    public partial class personalupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "First_name",
                table: "user");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "user");

            migrationBuilder.DropColumn(
                name: "Second_name",
                table: "user");

            migrationBuilder.AddColumn<string>(
                name: "First_name",
                table: "personal",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Second_name",
                table: "personal",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "First_name",
                table: "personal");

            migrationBuilder.DropColumn(
                name: "Second_name",
                table: "personal");

            migrationBuilder.AddColumn<string>(
                name: "First_name",
                table: "user",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "user",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Second_name",
                table: "user",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
