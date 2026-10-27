using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaktabTaha.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MoshaverIdChangesInMoshavereh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MoshaverCode",
                table: "Moshavereh");

            migrationBuilder.AddColumn<int>(
                name: "MoshaverId",
                table: "Moshavereh",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Moshavereh_MoshaverId",
                table: "Moshavereh",
                column: "MoshaverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Moshavereh_Donor_MoshaverId",
                table: "Moshavereh",
                column: "MoshaverId",
                principalTable: "Donor",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Moshavereh_Donor_MoshaverId",
                table: "Moshavereh");

            migrationBuilder.DropIndex(
                name: "IX_Moshavereh_MoshaverId",
                table: "Moshavereh");

            migrationBuilder.DropColumn(
                name: "MoshaverId",
                table: "Moshavereh");

            migrationBuilder.AddColumn<string>(
                name: "MoshaverCode",
                table: "Moshavereh",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
