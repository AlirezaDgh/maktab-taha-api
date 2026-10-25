using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaktabTaha.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCaseName1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachment_CaseDesc_CaseId",
                table: "Attachment");

            migrationBuilder.DropForeignKey(
                name: "FK_Attachment_CaseDesc_CaseId1",
                table: "Attachment");

            migrationBuilder.DropForeignKey(
                name: "FK_CaseDesc_Area_AreaId",
                table: "CaseDesc");

            migrationBuilder.DropForeignKey(
                name: "FK_CaseDesc_Bank_BankId",
                table: "CaseDesc");

            migrationBuilder.DropForeignKey(
                name: "FK_CaseDesc_CaseStage_CaseStageId",
                table: "CaseDesc");

            migrationBuilder.DropForeignKey(
                name: "FK_CaseDesc_CaseType_CaseTypeId",
                table: "CaseDesc");

            migrationBuilder.DropForeignKey(
                name: "FK_CaseDesc_City_CityId",
                table: "CaseDesc");

            migrationBuilder.DropForeignKey(
                name: "FK_CaseDesc_Donor_ReferrerId",
                table: "CaseDesc");

            migrationBuilder.DropForeignKey(
                name: "FK_CaseDesc_HouseHeadStatus_HouseHeadStatusId",
                table: "CaseDesc");

            migrationBuilder.DropForeignKey(
                name: "FK_CaseDesc_PrivatenessStatus_PrivatenessStatusId",
                table: "CaseDesc");

            migrationBuilder.DropForeignKey(
                name: "FK_CaseDesc_Province_ProvinceId",
                table: "CaseDesc");

            migrationBuilder.DropForeignKey(
                name: "FK_CaseDesc_Request_RequestId",
                table: "CaseDesc");

            migrationBuilder.DropForeignKey(
                name: "FK_CasePerson_CaseDesc_CaseId",
                table: "CasePerson");

            migrationBuilder.DropForeignKey(
                name: "FK_CasePerson_CaseDesc_CaseId1",
                table: "CasePerson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CaseDesc",
                table: "CaseDesc");

            migrationBuilder.RenameTable(
                name: "CaseDesc",
                newName: "CaseBNF");

            migrationBuilder.RenameIndex(
                name: "IX_CaseDesc_RequestId",
                table: "CaseBNF",
                newName: "IX_CaseBNF_RequestId");

            migrationBuilder.RenameIndex(
                name: "IX_CaseDesc_ReferrerId",
                table: "CaseBNF",
                newName: "IX_CaseBNF_ReferrerId");

            migrationBuilder.RenameIndex(
                name: "IX_CaseDesc_ProvinceId",
                table: "CaseBNF",
                newName: "IX_CaseBNF_ProvinceId");

            migrationBuilder.RenameIndex(
                name: "IX_CaseDesc_PrivatenessStatusId",
                table: "CaseBNF",
                newName: "IX_CaseBNF_PrivatenessStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_CaseDesc_HouseHeadStatusId",
                table: "CaseBNF",
                newName: "IX_CaseBNF_HouseHeadStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_CaseDesc_CityId",
                table: "CaseBNF",
                newName: "IX_CaseBNF_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_CaseDesc_CaseTypeId",
                table: "CaseBNF",
                newName: "IX_CaseBNF_CaseTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_CaseDesc_CaseStageId",
                table: "CaseBNF",
                newName: "IX_CaseBNF_CaseStageId");

            migrationBuilder.RenameIndex(
                name: "IX_CaseDesc_BankId",
                table: "CaseBNF",
                newName: "IX_CaseBNF_BankId");

            migrationBuilder.RenameIndex(
                name: "IX_CaseDesc_AreaId",
                table: "CaseBNF",
                newName: "IX_CaseBNF_AreaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CaseBNF",
                table: "CaseBNF",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachment_CaseBNF_CaseId",
                table: "Attachment",
                column: "CaseId",
                principalTable: "CaseBNF",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attachment_CaseBNF_CaseId1",
                table: "Attachment",
                column: "CaseId1",
                principalTable: "CaseBNF",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseBNF_Area_AreaId",
                table: "CaseBNF",
                column: "AreaId",
                principalTable: "Area",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CaseBNF_Bank_BankId",
                table: "CaseBNF",
                column: "BankId",
                principalTable: "Bank",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CaseBNF_CaseStage_CaseStageId",
                table: "CaseBNF",
                column: "CaseStageId",
                principalTable: "CaseStage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CaseBNF_CaseType_CaseTypeId",
                table: "CaseBNF",
                column: "CaseTypeId",
                principalTable: "CaseType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CaseBNF_City_CityId",
                table: "CaseBNF",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CaseBNF_Donor_ReferrerId",
                table: "CaseBNF",
                column: "ReferrerId",
                principalTable: "Donor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CaseBNF_HouseHeadStatus_HouseHeadStatusId",
                table: "CaseBNF",
                column: "HouseHeadStatusId",
                principalTable: "HouseHeadStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CaseBNF_PrivatenessStatus_PrivatenessStatusId",
                table: "CaseBNF",
                column: "PrivatenessStatusId",
                principalTable: "PrivatenessStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CaseBNF_Province_ProvinceId",
                table: "CaseBNF",
                column: "ProvinceId",
                principalTable: "Province",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CaseBNF_Request_RequestId",
                table: "CaseBNF",
                column: "RequestId",
                principalTable: "Request",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CasePerson_CaseBNF_CaseId",
                table: "CasePerson",
                column: "CaseId",
                principalTable: "CaseBNF",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CasePerson_CaseBNF_CaseId1",
                table: "CasePerson",
                column: "CaseId1",
                principalTable: "CaseBNF",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachment_CaseBNF_CaseId",
                table: "Attachment");

            migrationBuilder.DropForeignKey(
                name: "FK_Attachment_CaseBNF_CaseId1",
                table: "Attachment");

            migrationBuilder.DropForeignKey(
                name: "FK_CaseBNF_Area_AreaId",
                table: "CaseBNF");

            migrationBuilder.DropForeignKey(
                name: "FK_CaseBNF_Bank_BankId",
                table: "CaseBNF");

            migrationBuilder.DropForeignKey(
                name: "FK_CaseBNF_CaseStage_CaseStageId",
                table: "CaseBNF");

            migrationBuilder.DropForeignKey(
                name: "FK_CaseBNF_CaseType_CaseTypeId",
                table: "CaseBNF");

            migrationBuilder.DropForeignKey(
                name: "FK_CaseBNF_City_CityId",
                table: "CaseBNF");

            migrationBuilder.DropForeignKey(
                name: "FK_CaseBNF_Donor_ReferrerId",
                table: "CaseBNF");

            migrationBuilder.DropForeignKey(
                name: "FK_CaseBNF_HouseHeadStatus_HouseHeadStatusId",
                table: "CaseBNF");

            migrationBuilder.DropForeignKey(
                name: "FK_CaseBNF_PrivatenessStatus_PrivatenessStatusId",
                table: "CaseBNF");

            migrationBuilder.DropForeignKey(
                name: "FK_CaseBNF_Province_ProvinceId",
                table: "CaseBNF");

            migrationBuilder.DropForeignKey(
                name: "FK_CaseBNF_Request_RequestId",
                table: "CaseBNF");

            migrationBuilder.DropForeignKey(
                name: "FK_CasePerson_CaseBNF_CaseId",
                table: "CasePerson");

            migrationBuilder.DropForeignKey(
                name: "FK_CasePerson_CaseBNF_CaseId1",
                table: "CasePerson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CaseBNF",
                table: "CaseBNF");

            migrationBuilder.RenameTable(
                name: "CaseBNF",
                newName: "CaseDesc");

            migrationBuilder.RenameIndex(
                name: "IX_CaseBNF_RequestId",
                table: "CaseDesc",
                newName: "IX_CaseDesc_RequestId");

            migrationBuilder.RenameIndex(
                name: "IX_CaseBNF_ReferrerId",
                table: "CaseDesc",
                newName: "IX_CaseDesc_ReferrerId");

            migrationBuilder.RenameIndex(
                name: "IX_CaseBNF_ProvinceId",
                table: "CaseDesc",
                newName: "IX_CaseDesc_ProvinceId");

            migrationBuilder.RenameIndex(
                name: "IX_CaseBNF_PrivatenessStatusId",
                table: "CaseDesc",
                newName: "IX_CaseDesc_PrivatenessStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_CaseBNF_HouseHeadStatusId",
                table: "CaseDesc",
                newName: "IX_CaseDesc_HouseHeadStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_CaseBNF_CityId",
                table: "CaseDesc",
                newName: "IX_CaseDesc_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_CaseBNF_CaseTypeId",
                table: "CaseDesc",
                newName: "IX_CaseDesc_CaseTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_CaseBNF_CaseStageId",
                table: "CaseDesc",
                newName: "IX_CaseDesc_CaseStageId");

            migrationBuilder.RenameIndex(
                name: "IX_CaseBNF_BankId",
                table: "CaseDesc",
                newName: "IX_CaseDesc_BankId");

            migrationBuilder.RenameIndex(
                name: "IX_CaseBNF_AreaId",
                table: "CaseDesc",
                newName: "IX_CaseDesc_AreaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CaseDesc",
                table: "CaseDesc",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachment_CaseDesc_CaseId",
                table: "Attachment",
                column: "CaseId",
                principalTable: "CaseDesc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attachment_CaseDesc_CaseId1",
                table: "Attachment",
                column: "CaseId1",
                principalTable: "CaseDesc",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseDesc_Area_AreaId",
                table: "CaseDesc",
                column: "AreaId",
                principalTable: "Area",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CaseDesc_Bank_BankId",
                table: "CaseDesc",
                column: "BankId",
                principalTable: "Bank",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CaseDesc_CaseStage_CaseStageId",
                table: "CaseDesc",
                column: "CaseStageId",
                principalTable: "CaseStage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CaseDesc_CaseType_CaseTypeId",
                table: "CaseDesc",
                column: "CaseTypeId",
                principalTable: "CaseType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CaseDesc_City_CityId",
                table: "CaseDesc",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CaseDesc_Donor_ReferrerId",
                table: "CaseDesc",
                column: "ReferrerId",
                principalTable: "Donor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CaseDesc_HouseHeadStatus_HouseHeadStatusId",
                table: "CaseDesc",
                column: "HouseHeadStatusId",
                principalTable: "HouseHeadStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CaseDesc_PrivatenessStatus_PrivatenessStatusId",
                table: "CaseDesc",
                column: "PrivatenessStatusId",
                principalTable: "PrivatenessStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CaseDesc_Province_ProvinceId",
                table: "CaseDesc",
                column: "ProvinceId",
                principalTable: "Province",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CaseDesc_Request_RequestId",
                table: "CaseDesc",
                column: "RequestId",
                principalTable: "Request",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CasePerson_CaseDesc_CaseId",
                table: "CasePerson",
                column: "CaseId",
                principalTable: "CaseDesc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CasePerson_CaseDesc_CaseId1",
                table: "CasePerson",
                column: "CaseId1",
                principalTable: "CaseDesc",
                principalColumn: "Id");
        }
    }
}
