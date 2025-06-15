using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiplomUchetSC.Migrations
{
    /// <inheritdoc />
    public partial class _1231321 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "user",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "user");
        }
    }
}
