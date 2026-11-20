using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaktabTaha.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CaseDonorHelpsOnvani : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CaseDonorHelpsOnvani",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OnvaniPageId = table.Column<int>(type: "int", nullable: false),
                    CaseNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RequestTypeId = table.Column<int>(type: "int", nullable: false),
                    MoneyAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DonorId = table.Column<int>(type: "int", nullable: false),
                    FromDate = table.Column<DateTime>(type: "Date", nullable: true),
                    ToDate = table.Column<DateTime>(type: "Date", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseDonorHelpsOnvani", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseDonorHelpsOnvani_CaseBNF_CaseNumber",
                        column: x => x.CaseNumber,
                        principalTable: "CaseBNF",
                        principalColumn: "CaseNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaseDonorHelpsOnvani_Donor_DonorId",
                        column: x => x.DonorId,
                        principalTable: "Donor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CaseDonorHelpsOnvani_OnvaniPage_OnvaniPageId",
                        column: x => x.OnvaniPageId,
                        principalTable: "OnvaniPage",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CaseDonorHelpsOnvani_RequestType_RequestTypeId",
                        column: x => x.RequestTypeId,
                        principalTable: "RequestType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaseDonorHelpsOnvani_CaseNumber",
                table: "CaseDonorHelpsOnvani",
                column: "CaseNumber");

            migrationBuilder.CreateIndex(
                name: "IX_CaseDonorHelpsOnvani_DonorId",
                table: "CaseDonorHelpsOnvani",
                column: "DonorId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseDonorHelpsOnvani_OnvaniPageId",
                table: "CaseDonorHelpsOnvani",
                column: "OnvaniPageId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseDonorHelpsOnvani_RequestTypeId",
                table: "CaseDonorHelpsOnvani",
                column: "RequestTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaseDonorHelpsOnvani");
        }
    }
}
