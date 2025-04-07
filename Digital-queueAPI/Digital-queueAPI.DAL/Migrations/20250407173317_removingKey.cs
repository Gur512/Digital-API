using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Digital_queueAPI.DAL.Migrations
{
    /// <inheritdoc />
    public partial class removingKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusinessId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BusinessId",
                table: "Queues");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BusinessId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BusinessId",
                table: "Queues",
                type: "int",
                nullable: true);
        }
    }
}
