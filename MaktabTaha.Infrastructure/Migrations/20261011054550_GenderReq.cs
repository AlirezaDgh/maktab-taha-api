using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaktabTaha.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class GenderReq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Request");

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "Request",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Request_GenderId",
                table: "Request",
                column: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Gender_GenderId",
                table: "Request",
                column: "GenderId",
                principalTable: "Gender",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_Gender_GenderId",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_GenderId",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "Request");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Request",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
