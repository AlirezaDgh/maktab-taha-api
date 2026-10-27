using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaktabTaha.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TahghighMohagheghChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstMohagheghCode",
                table: "Tahghigh");

            migrationBuilder.DropColumn(
                name: "SecondMohagheghCode",
                table: "Tahghigh");

            migrationBuilder.AddColumn<int>(
                name: "FirstMohagheghId",
                table: "Tahghigh",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SecondMohagheghId",
                table: "Tahghigh",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tahghigh_FirstMohagheghId",
                table: "Tahghigh",
                column: "FirstMohagheghId");

            migrationBuilder.CreateIndex(
                name: "IX_Tahghigh_SecondMohagheghId",
                table: "Tahghigh",
                column: "SecondMohagheghId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tahghigh_Donor_FirstMohagheghId",
                table: "Tahghigh",
                column: "FirstMohagheghId",
                principalTable: "Donor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tahghigh_Donor_SecondMohagheghId",
                table: "Tahghigh",
                column: "SecondMohagheghId",
                principalTable: "Donor",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tahghigh_Donor_FirstMohagheghId",
                table: "Tahghigh");

            migrationBuilder.DropForeignKey(
                name: "FK_Tahghigh_Donor_SecondMohagheghId",
                table: "Tahghigh");

            migrationBuilder.DropIndex(
                name: "IX_Tahghigh_FirstMohagheghId",
                table: "Tahghigh");

            migrationBuilder.DropIndex(
                name: "IX_Tahghigh_SecondMohagheghId",
                table: "Tahghigh");

            migrationBuilder.DropColumn(
                name: "FirstMohagheghId",
                table: "Tahghigh");

            migrationBuilder.DropColumn(
                name: "SecondMohagheghId",
                table: "Tahghigh");

            migrationBuilder.AddColumn<string>(
                name: "FirstMohagheghCode",
                table: "Tahghigh",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecondMohagheghCode",
                table: "Tahghigh",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
