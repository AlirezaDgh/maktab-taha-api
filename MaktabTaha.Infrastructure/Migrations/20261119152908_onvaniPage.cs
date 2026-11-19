using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaktabTaha.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class onvaniPage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OnvaniPageId",
                table: "Attachment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "OnvaniPage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CaseNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RequestTypeId = table.Column<int>(type: "int", nullable: false),
                    HelpMoney = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreateDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoshaverIdea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeadOfWorkingGroupId = table.Column<int>(type: "int", nullable: false),
                    MoshaverId = table.Column<int>(type: "int", nullable: false),
                    TasvibStatusId = table.Column<int>(type: "int", nullable: true, defaultValue: 1),
                    TasvibReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApproveDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManagerTasvibStatusId = table.Column<int>(type: "int", nullable: true, defaultValue: 1),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnvaniPage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OnvaniPage_CaseBNF_CaseNumber",
                        column: x => x.CaseNumber,
                        principalTable: "CaseBNF",
                        principalColumn: "CaseNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OnvaniPage_Donor_HeadOfWorkingGroupId",
                        column: x => x.HeadOfWorkingGroupId,
                        principalTable: "Donor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OnvaniPage_Donor_MoshaverId",
                        column: x => x.MoshaverId,
                        principalTable: "Donor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OnvaniPage_ManagerTasvibStatus_ManagerTasvibStatusId",
                        column: x => x.ManagerTasvibStatusId,
                        principalTable: "ManagerTasvibStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OnvaniPage_RequestType_RequestTypeId",
                        column: x => x.RequestTypeId,
                        principalTable: "RequestType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OnvaniPage_TasvibStatus_TasvibStatusId",
                        column: x => x.TasvibStatusId,
                        principalTable: "TasvibStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_OnvaniPageId",
                table: "Attachment",
                column: "OnvaniPageId");

            migrationBuilder.CreateIndex(
                name: "IX_OnvaniPage_CaseNumber",
                table: "OnvaniPage",
                column: "CaseNumber");

            migrationBuilder.CreateIndex(
                name: "IX_OnvaniPage_HeadOfWorkingGroupId",
                table: "OnvaniPage",
                column: "HeadOfWorkingGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_OnvaniPage_ManagerTasvibStatusId",
                table: "OnvaniPage",
                column: "ManagerTasvibStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_OnvaniPage_MoshaverId",
                table: "OnvaniPage",
                column: "MoshaverId");

            migrationBuilder.CreateIndex(
                name: "IX_OnvaniPage_RequestTypeId",
                table: "OnvaniPage",
                column: "RequestTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OnvaniPage_TasvibStatusId",
                table: "OnvaniPage",
                column: "TasvibStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachment_OnvaniPage_OnvaniPageId",
                table: "Attachment",
                column: "OnvaniPageId",
                principalTable: "OnvaniPage",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachment_OnvaniPage_OnvaniPageId",
                table: "Attachment");

            migrationBuilder.DropTable(
                name: "OnvaniPage");

            migrationBuilder.DropIndex(
                name: "IX_Attachment_OnvaniPageId",
                table: "Attachment");

            migrationBuilder.DropColumn(
                name: "OnvaniPageId",
                table: "Attachment");
        }
    }
}
