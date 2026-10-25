using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaktabTaha.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Tahghigh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachment_CaseBNF_CaseId",
                table: "Attachment");

            migrationBuilder.DropForeignKey(
                name: "FK_Attachment_Person_PersonId",
                table: "Attachment");

            migrationBuilder.AddColumn<DateTime>(
                name: "MoshaverehDate",
                table: "Moshavereh",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "TahghighId",
                table: "Attachment",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TahghighId1",
                table: "Attachment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tahghigh",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TahghighDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MoshaverehId = table.Column<int>(type: "int", nullable: false),
                    ClientDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstMohagheghCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondMohagheghCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MohagheghIdea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MohagheghDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tahghigh", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tahghigh_Moshavereh_MoshaverehId",
                        column: x => x.MoshaverehId,
                        principalTable: "Moshavereh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_TahghighId",
                table: "Attachment",
                column: "TahghighId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_TahghighId1",
                table: "Attachment",
                column: "TahghighId1");

            migrationBuilder.CreateIndex(
                name: "IX_Tahghigh_MoshaverehId",
                table: "Tahghigh",
                column: "MoshaverehId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachment_CaseBNF_CaseId",
                table: "Attachment",
                column: "CaseId",
                principalTable: "CaseBNF",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachment_Person_PersonId",
                table: "Attachment",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachment_Tahghigh_TahghighId",
                table: "Attachment",
                column: "TahghighId",
                principalTable: "Tahghigh",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachment_Tahghigh_TahghighId1",
                table: "Attachment",
                column: "TahghighId1",
                principalTable: "Tahghigh",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachment_CaseBNF_CaseId",
                table: "Attachment");

            migrationBuilder.DropForeignKey(
                name: "FK_Attachment_Person_PersonId",
                table: "Attachment");

            migrationBuilder.DropForeignKey(
                name: "FK_Attachment_Tahghigh_TahghighId",
                table: "Attachment");

            migrationBuilder.DropForeignKey(
                name: "FK_Attachment_Tahghigh_TahghighId1",
                table: "Attachment");

            migrationBuilder.DropTable(
                name: "Tahghigh");

            migrationBuilder.DropIndex(
                name: "IX_Attachment_TahghighId",
                table: "Attachment");

            migrationBuilder.DropIndex(
                name: "IX_Attachment_TahghighId1",
                table: "Attachment");

            migrationBuilder.DropColumn(
                name: "MoshaverehDate",
                table: "Moshavereh");

            migrationBuilder.DropColumn(
                name: "TahghighId",
                table: "Attachment");

            migrationBuilder.DropColumn(
                name: "TahghighId1",
                table: "Attachment");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachment_CaseBNF_CaseId",
                table: "Attachment",
                column: "CaseId",
                principalTable: "CaseBNF",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attachment_Person_PersonId",
                table: "Attachment",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
