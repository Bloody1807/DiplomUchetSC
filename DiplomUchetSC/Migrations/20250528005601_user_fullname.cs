using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiplomUchetSC.Migrations
{
    /// <inheritdoc />
    public partial class user_fullname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "First_name",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Last_name",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "Second_name",
                table: "Clients",
                newName: "Full_name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Full_name",
                table: "Clients",
                newName: "Second_name");

            migrationBuilder.AddColumn<string>(
                name: "First_name",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Last_name",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
