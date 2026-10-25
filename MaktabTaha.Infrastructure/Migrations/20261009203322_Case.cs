using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaktabTaha.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Case : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaseLevel");

            migrationBuilder.RenameColumn(
                name: "AttachmentName",
                table: "Attachment",
                newName: "AttachmentType");

            migrationBuilder.AddColumn<int>(
                name: "CaseId",
                table: "Attachment",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CaseId1",
                table: "Attachment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CaseStage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseStageDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseStage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Case",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseNumber = table.Column<int>(type: "int", nullable: false),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    CaseTypeId = table.Column<int>(type: "int", nullable: false),
                    PrivatenessStatusId = table.Column<int>(type: "int", nullable: false),
                    HouseHeadStatusId = table.Column<int>(type: "int", nullable: false),
                    ReferrerId = table.Column<int>(type: "int", nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    AddressDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomeNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankId = table.Column<int>(type: "int", nullable: false),
                    BankBranchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankBranchCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IBAN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaseStageId = table.Column<int>(type: "int", nullable: false),
                    ActiveStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Case", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Case_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Case_Bank_BankId",
                        column: x => x.BankId,
                        principalTable: "Bank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Case_CaseStage_CaseStageId",
                        column: x => x.CaseStageId,
                        principalTable: "CaseStage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Case_CaseType_CaseTypeId",
                        column: x => x.CaseTypeId,
                        principalTable: "CaseType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Case_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Case_Donor_ReferrerId",
                        column: x => x.ReferrerId,
                        principalTable: "Donor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Case_HouseHeadStatus_HouseHeadStatusId",
                        column: x => x.HouseHeadStatusId,
                        principalTable: "HouseHeadStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Case_PrivatenessStatus_PrivatenessStatusId",
                        column: x => x.PrivatenessStatusId,
                        principalTable: "PrivatenessStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Case_Province_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Province",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Case_Request_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Request",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CasePerson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    RelationId = table.Column<int>(type: "int", nullable: false),
                    IsDependent = table.Column<int>(type: "int", nullable: false),
                    CaseId1 = table.Column<int>(type: "int", nullable: true),
                    PersonId1 = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CasePerson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CasePerson_Case_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Case",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CasePerson_Case_CaseId1",
                        column: x => x.CaseId1,
                        principalTable: "Case",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CasePerson_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CasePerson_Person_PersonId1",
                        column: x => x.PersonId1,
                        principalTable: "Person",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CasePerson_Relation_RelationId",
                        column: x => x.RelationId,
                        principalTable: "Relation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_CaseId",
                table: "Attachment",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_CaseId1",
                table: "Attachment",
                column: "CaseId1");

            migrationBuilder.CreateIndex(
                name: "IX_Case_AreaId",
                table: "Case",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Case_BankId",
                table: "Case",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Case_CaseStageId",
                table: "Case",
                column: "CaseStageId");

            migrationBuilder.CreateIndex(
                name: "IX_Case_CaseTypeId",
                table: "Case",
                column: "CaseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Case_CityId",
                table: "Case",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Case_HouseHeadStatusId",
                table: "Case",
                column: "HouseHeadStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Case_PrivatenessStatusId",
                table: "Case",
                column: "PrivatenessStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Case_ProvinceId",
                table: "Case",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Case_ReferrerId",
                table: "Case",
                column: "ReferrerId");

            migrationBuilder.CreateIndex(
                name: "IX_Case_RequestId",
                table: "Case",
                column: "RequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CasePerson_CaseId",
                table: "CasePerson",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_CasePerson_CaseId1",
                table: "CasePerson",
                column: "CaseId1");

            migrationBuilder.CreateIndex(
                name: "IX_CasePerson_PersonId",
                table: "CasePerson",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_CasePerson_PersonId1",
                table: "CasePerson",
                column: "PersonId1");

            migrationBuilder.CreateIndex(
                name: "IX_CasePerson_RelationId",
                table: "CasePerson",
                column: "RelationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachment_Case_CaseId",
                table: "Attachment",
                column: "CaseId",
                principalTable: "Case",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attachment_Case_CaseId1",
                table: "Attachment",
                column: "CaseId1",
                principalTable: "Case",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachment_Case_CaseId",
                table: "Attachment");

            migrationBuilder.DropForeignKey(
                name: "FK_Attachment_Case_CaseId1",
                table: "Attachment");

            migrationBuilder.DropTable(
                name: "CasePerson");

            migrationBuilder.DropTable(
                name: "Case");

            migrationBuilder.DropTable(
                name: "CaseStage");

            migrationBuilder.DropIndex(
                name: "IX_Attachment_CaseId",
                table: "Attachment");

            migrationBuilder.DropIndex(
                name: "IX_Attachment_CaseId1",
                table: "Attachment");

            migrationBuilder.DropColumn(
                name: "CaseId",
                table: "Attachment");

            migrationBuilder.DropColumn(
                name: "CaseId1",
                table: "Attachment");

            migrationBuilder.RenameColumn(
                name: "AttachmentType",
                table: "Attachment",
                newName: "AttachmentName");

            migrationBuilder.CreateTable(
                name: "CaseLevel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseLevelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseLevel", x => x.Id);
                });
        }
    }
}
