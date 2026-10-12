using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaktabTaha.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Moshavereh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CasePerson_CaseBNF_CaseId1",
                table: "CasePerson");

            migrationBuilder.DropForeignKey(
                name: "FK_CasePerson_Person_PersonId1",
                table: "CasePerson");

            migrationBuilder.DropIndex(
                name: "IX_CasePerson_CaseId1",
                table: "CasePerson");

            migrationBuilder.DropIndex(
                name: "IX_CasePerson_PersonId1",
                table: "CasePerson");

            migrationBuilder.DropColumn(
                name: "CaseId1",
                table: "CasePerson");

            migrationBuilder.DropColumn(
                name: "PersonId1",
                table: "CasePerson");

            migrationBuilder.AlterColumn<string>(
                name: "CaseNumber",
                table: "CaseBNF",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "MoshaverehId",
                table: "Attachment",
                type: "int",
                nullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_CaseBNF_CaseNumber",
                table: "CaseBNF",
                column: "CaseNumber");

            migrationBuilder.CreateTable(
                name: "Moshavereh",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClientRequestDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoshaverCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoshaverIdea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoshaverExplaination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moshavereh", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Moshavereh_CaseBNF_CaseNumber",
                        column: x => x.CaseNumber,
                        principalTable: "CaseBNF",
                        principalColumn: "CaseNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_MoshaverehId",
                table: "Attachment",
                column: "MoshaverehId");

            migrationBuilder.CreateIndex(
                name: "IX_Moshavereh_CaseNumber",
                table: "Moshavereh",
                column: "CaseNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachment_Moshavereh_MoshaverehId",
                table: "Attachment",
                column: "MoshaverehId",
                principalTable: "Moshavereh",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachment_Moshavereh_MoshaverehId",
                table: "Attachment");

            migrationBuilder.DropTable(
                name: "Moshavereh");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_CaseBNF_CaseNumber",
                table: "CaseBNF");

            migrationBuilder.DropIndex(
                name: "IX_Attachment_MoshaverehId",
                table: "Attachment");

            migrationBuilder.DropColumn(
                name: "MoshaverehId",
                table: "Attachment");

            migrationBuilder.AddColumn<int>(
                name: "CaseId1",
                table: "CasePerson",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonId1",
                table: "CasePerson",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CaseNumber",
                table: "CaseBNF",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_CasePerson_CaseId1",
                table: "CasePerson",
                column: "CaseId1");

            migrationBuilder.CreateIndex(
                name: "IX_CasePerson_PersonId1",
                table: "CasePerson",
                column: "PersonId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CasePerson_CaseBNF_CaseId1",
                table: "CasePerson",
                column: "CaseId1",
                principalTable: "CaseBNF",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CasePerson_Person_PersonId1",
                table: "CasePerson",
                column: "PersonId1",
                principalTable: "Person",
                principalColumn: "Id");
        }
    }
}
