using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaktabTaha.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCaseName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachment_Case_CaseId",
                table: "Attachment");

            migrationBuilder.DropForeignKey(
                name: "FK_Attachment_Case_CaseId1",
                table: "Attachment");

            migrationBuilder.DropForeignKey(
                name: "FK_Case_Area_AreaId",
                table: "Case");

            migrationBuilder.DropForeignKey(
                name: "FK_Case_Bank_BankId",
                table: "Case");

            migrationBuilder.DropForeignKey(
                name: "FK_Case_CaseStage_CaseStageId",
                table: "Case");

            migrationBuilder.DropForeignKey(
                name: "FK_Case_CaseType_CaseTypeId",
                table: "Case");

            migrationBuilder.DropForeignKey(
                name: "FK_Case_City_CityId",
                table: "Case");

            migrationBuilder.DropForeignKey(
                name: "FK_Case_Donor_ReferrerId",
                table: "Case");

            migrationBuilder.DropForeignKey(
                name: "FK_Case_HouseHeadStatus_HouseHeadStatusId",
                table: "Case");

            migrationBuilder.DropForeignKey(
                name: "FK_Case_PrivatenessStatus_PrivatenessStatusId",
                table: "Case");

            migrationBuilder.DropForeignKey(
                name: "FK_Case_Province_ProvinceId",
                table: "Case");

            migrationBuilder.DropForeignKey(
                name: "FK_Case_Request_RequestId",
                table: "Case");

            migrationBuilder.DropForeignKey(
                name: "FK_CasePerson_Case_CaseId",
                table: "CasePerson");

            migrationBuilder.DropForeignKey(
                name: "FK_CasePerson_Case_CaseId1",
                table: "CasePerson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Case",
                table: "Case");

            migrationBuilder.RenameTable(
                name: "Case",
                newName: "CaseDesc");

            migrationBuilder.RenameIndex(
                name: "IX_Case_RequestId",
                table: "CaseDesc",
                newName: "IX_CaseDesc_RequestId");

            migrationBuilder.RenameIndex(
                name: "IX_Case_ReferrerId",
                table: "CaseDesc",
                newName: "IX_CaseDesc_ReferrerId");

            migrationBuilder.RenameIndex(
                name: "IX_Case_ProvinceId",
                table: "CaseDesc",
                newName: "IX_CaseDesc_ProvinceId");

            migrationBuilder.RenameIndex(
                name: "IX_Case_PrivatenessStatusId",
                table: "CaseDesc",
                newName: "IX_CaseDesc_PrivatenessStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Case_HouseHeadStatusId",
                table: "CaseDesc",
                newName: "IX_CaseDesc_HouseHeadStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Case_CityId",
                table: "CaseDesc",
                newName: "IX_CaseDesc_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Case_CaseTypeId",
                table: "CaseDesc",
                newName: "IX_CaseDesc_CaseTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Case_CaseStageId",
                table: "CaseDesc",
                newName: "IX_CaseDesc_CaseStageId");

            migrationBuilder.RenameIndex(
                name: "IX_Case_BankId",
                table: "CaseDesc",
                newName: "IX_CaseDesc_BankId");

            migrationBuilder.RenameIndex(
                name: "IX_Case_AreaId",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                newName: "Case");

            migrationBuilder.RenameIndex(
                name: "IX_CaseDesc_RequestId",
                table: "Case",
                newName: "IX_Case_RequestId");

            migrationBuilder.RenameIndex(
                name: "IX_CaseDesc_ReferrerId",
                table: "Case",
                newName: "IX_Case_ReferrerId");

            migrationBuilder.RenameIndex(
                name: "IX_CaseDesc_ProvinceId",
                table: "Case",
                newName: "IX_Case_ProvinceId");

            migrationBuilder.RenameIndex(
                name: "IX_CaseDesc_PrivatenessStatusId",
                table: "Case",
                newName: "IX_Case_PrivatenessStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_CaseDesc_HouseHeadStatusId",
                table: "Case",
                newName: "IX_Case_HouseHeadStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_CaseDesc_CityId",
                table: "Case",
                newName: "IX_Case_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_CaseDesc_CaseTypeId",
                table: "Case",
                newName: "IX_Case_CaseTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_CaseDesc_CaseStageId",
                table: "Case",
                newName: "IX_Case_CaseStageId");

            migrationBuilder.RenameIndex(
                name: "IX_CaseDesc_BankId",
                table: "Case",
                newName: "IX_Case_BankId");

            migrationBuilder.RenameIndex(
                name: "IX_CaseDesc_AreaId",
                table: "Case",
                newName: "IX_Case_AreaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Case",
                table: "Case",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Case_Area_AreaId",
                table: "Case",
                column: "AreaId",
                principalTable: "Area",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Case_Bank_BankId",
                table: "Case",
                column: "BankId",
                principalTable: "Bank",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Case_CaseStage_CaseStageId",
                table: "Case",
                column: "CaseStageId",
                principalTable: "CaseStage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Case_CaseType_CaseTypeId",
                table: "Case",
                column: "CaseTypeId",
                principalTable: "CaseType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Case_City_CityId",
                table: "Case",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Case_Donor_ReferrerId",
                table: "Case",
                column: "ReferrerId",
                principalTable: "Donor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Case_HouseHeadStatus_HouseHeadStatusId",
                table: "Case",
                column: "HouseHeadStatusId",
                principalTable: "HouseHeadStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Case_PrivatenessStatus_PrivatenessStatusId",
                table: "Case",
                column: "PrivatenessStatusId",
                principalTable: "PrivatenessStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Case_Province_ProvinceId",
                table: "Case",
                column: "ProvinceId",
                principalTable: "Province",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Case_Request_RequestId",
                table: "Case",
                column: "RequestId",
                principalTable: "Request",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CasePerson_Case_CaseId",
                table: "CasePerson",
                column: "CaseId",
                principalTable: "Case",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CasePerson_Case_CaseId1",
                table: "CasePerson",
                column: "CaseId1",
                principalTable: "Case",
                principalColumn: "Id");
        }
    }
}
