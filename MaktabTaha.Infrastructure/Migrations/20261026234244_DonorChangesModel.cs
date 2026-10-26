using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaktabTaha.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DonorChangesModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthPlace",
                table: "Donor");

            migrationBuilder.DropColumn(
                name: "CharityReferralSource",
                table: "Donor");

            migrationBuilder.RenameColumn(
                name: "DonorType",
                table: "Donor",
                newName: "NickName");

            migrationBuilder.AddColumn<int>(
                name: "BirthCityId",
                table: "Donor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BirthProvinceId",
                table: "Donor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CharityReferralSourceId",
                table: "Donor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DonorTypeId",
                table: "Donor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CharityReferralSource",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharityReferralSourceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharityReferralSource", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DonorType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonorTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonorType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Donor_BirthCityId",
                table: "Donor",
                column: "BirthCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Donor_BirthProvinceId",
                table: "Donor",
                column: "BirthProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Donor_CharityReferralSourceId",
                table: "Donor",
                column: "CharityReferralSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Donor_DonorTypeId",
                table: "Donor",
                column: "DonorTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donor_CharityReferralSource_CharityReferralSourceId",
                table: "Donor",
                column: "CharityReferralSourceId",
                principalTable: "CharityReferralSource",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Donor_City_BirthCityId",
                table: "Donor",
                column: "BirthCityId",
                principalTable: "City",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Donor_DonorType_DonorTypeId",
                table: "Donor",
                column: "DonorTypeId",
                principalTable: "DonorType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Donor_Province_BirthProvinceId",
                table: "Donor",
                column: "BirthProvinceId",
                principalTable: "Province",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donor_CharityReferralSource_CharityReferralSourceId",
                table: "Donor");

            migrationBuilder.DropForeignKey(
                name: "FK_Donor_City_BirthCityId",
                table: "Donor");

            migrationBuilder.DropForeignKey(
                name: "FK_Donor_DonorType_DonorTypeId",
                table: "Donor");

            migrationBuilder.DropForeignKey(
                name: "FK_Donor_Province_BirthProvinceId",
                table: "Donor");

            migrationBuilder.DropTable(
                name: "CharityReferralSource");

            migrationBuilder.DropTable(
                name: "DonorType");

            migrationBuilder.DropIndex(
                name: "IX_Donor_BirthCityId",
                table: "Donor");

            migrationBuilder.DropIndex(
                name: "IX_Donor_BirthProvinceId",
                table: "Donor");

            migrationBuilder.DropIndex(
                name: "IX_Donor_CharityReferralSourceId",
                table: "Donor");

            migrationBuilder.DropIndex(
                name: "IX_Donor_DonorTypeId",
                table: "Donor");

            migrationBuilder.DropColumn(
                name: "BirthCityId",
                table: "Donor");

            migrationBuilder.DropColumn(
                name: "BirthProvinceId",
                table: "Donor");

            migrationBuilder.DropColumn(
                name: "CharityReferralSourceId",
                table: "Donor");

            migrationBuilder.DropColumn(
                name: "DonorTypeId",
                table: "Donor");

            migrationBuilder.RenameColumn(
                name: "NickName",
                table: "Donor",
                newName: "DonorType");

            migrationBuilder.AddColumn<string>(
                name: "BirthPlace",
                table: "Donor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CharityReferralSource",
                table: "Donor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
