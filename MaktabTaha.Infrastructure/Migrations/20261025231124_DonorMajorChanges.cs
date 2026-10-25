using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaktabTaha.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DonorMajorChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Donor",
                newName: "ShenasnamehNumber");

            migrationBuilder.AlterColumn<string>(
                name: "NationalCode",
                table: "Donor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AvailableServices",
                table: "Donor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Donor",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "BirthPlace",
                table: "Donor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CharityJoinDate",
                table: "Donor",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CharityMainRoleId",
                table: "Donor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CharityReferralSource",
                table: "Donor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DonorType",
                table: "Donor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EducationLevelId",
                table: "Donor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EducationMajor",
                table: "Donor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EducationStatusId",
                table: "Donor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Donor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "Donor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "HomeAddress",
                table: "Donor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HomePhoneNumber",
                table: "Donor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "HouseCityId",
                table: "Donor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HouseProvinceId",
                table: "Donor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "JobAddress",
                table: "Donor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "JobId",
                table: "Donor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "JobPhoneNumber",
                table: "Donor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MaritalStatusId",
                table: "Donor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MobileNumber",
                table: "Donor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NationalityId",
                table: "Donor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReferrerId",
                table: "Donor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReligonId",
                table: "Donor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DonorId",
                table: "Attachment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Donor_CharityMainRoleId",
                table: "Donor",
                column: "CharityMainRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Donor_EducationLevelId",
                table: "Donor",
                column: "EducationLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Donor_EducationStatusId",
                table: "Donor",
                column: "EducationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Donor_GenderId",
                table: "Donor",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Donor_HouseCityId",
                table: "Donor",
                column: "HouseCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Donor_HouseProvinceId",
                table: "Donor",
                column: "HouseProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Donor_JobId",
                table: "Donor",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Donor_MaritalStatusId",
                table: "Donor",
                column: "MaritalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Donor_NationalityId",
                table: "Donor",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Donor_ReferrerId",
                table: "Donor",
                column: "ReferrerId");

            migrationBuilder.CreateIndex(
                name: "IX_Donor_ReligonId",
                table: "Donor",
                column: "ReligonId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_DonorId",
                table: "Attachment",
                column: "DonorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachment_Donor_DonorId",
                table: "Attachment",
                column: "DonorId",
                principalTable: "Donor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Donor_CharityMainRole_CharityMainRoleId",
                table: "Donor",
                column: "CharityMainRoleId",
                principalTable: "CharityMainRole",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Donor_City_HouseCityId",
                table: "Donor",
                column: "HouseCityId",
                principalTable: "City",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Donor_Donor_ReferrerId",
                table: "Donor",
                column: "ReferrerId",
                principalTable: "Donor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Donor_EducationLevel_EducationLevelId",
                table: "Donor",
                column: "EducationLevelId",
                principalTable: "EducationLevel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Donor_EducationStatus_EducationStatusId",
                table: "Donor",
                column: "EducationStatusId",
                principalTable: "EducationStatus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Donor_Gender_GenderId",
                table: "Donor",
                column: "GenderId",
                principalTable: "Gender",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Donor_Job_JobId",
                table: "Donor",
                column: "JobId",
                principalTable: "Job",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Donor_MaritalStatus_MaritalStatusId",
                table: "Donor",
                column: "MaritalStatusId",
                principalTable: "MaritalStatus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Donor_Nationality_NationalityId",
                table: "Donor",
                column: "NationalityId",
                principalTable: "Nationality",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Donor_Province_HouseProvinceId",
                table: "Donor",
                column: "HouseProvinceId",
                principalTable: "Province",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Donor_Religon_ReligonId",
                table: "Donor",
                column: "ReligonId",
                principalTable: "Religon",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachment_Donor_DonorId",
                table: "Attachment");

            migrationBuilder.DropForeignKey(
                name: "FK_Donor_CharityMainRole_CharityMainRoleId",
                table: "Donor");

            migrationBuilder.DropForeignKey(
                name: "FK_Donor_City_HouseCityId",
                table: "Donor");

            migrationBuilder.DropForeignKey(
                name: "FK_Donor_Donor_ReferrerId",
                table: "Donor");

            migrationBuilder.DropForeignKey(
                name: "FK_Donor_EducationLevel_EducationLevelId",
                table: "Donor");

            migrationBuilder.DropForeignKey(
                name: "FK_Donor_EducationStatus_EducationStatusId",
                table: "Donor");

            migrationBuilder.DropForeignKey(
                name: "FK_Donor_Gender_GenderId",
                table: "Donor");

            migrationBuilder.DropForeignKey(
                name: "FK_Donor_Job_JobId",
                table: "Donor");

            migrationBuilder.DropForeignKey(
                name: "FK_Donor_MaritalStatus_MaritalStatusId",
                table: "Donor");

            migrationBuilder.DropForeignKey(
                name: "FK_Donor_Nationality_NationalityId",
                table: "Donor");

            migrationBuilder.DropForeignKey(
                name: "FK_Donor_Province_HouseProvinceId",
                table: "Donor");

            migrationBuilder.DropForeignKey(
                name: "FK_Donor_Religon_ReligonId",
                table: "Donor");

            migrationBuilder.DropIndex(
                name: "IX_Donor_CharityMainRoleId",
                table: "Donor");

            migrationBuilder.DropIndex(
                name: "IX_Donor_EducationLevelId",
                table: "Donor");

            migrationBuilder.DropIndex(
                name: "IX_Donor_EducationStatusId",
                table: "Donor");

            migrationBuilder.DropIndex(
                name: "IX_Donor_GenderId",
                table: "Donor");

            migrationBuilder.DropIndex(
                name: "IX_Donor_HouseCityId",
                table: "Donor");

            migrationBuilder.DropIndex(
                name: "IX_Donor_HouseProvinceId",
                table: "Donor");

            migrationBuilder.DropIndex(
                name: "IX_Donor_JobId",
                table: "Donor");

            migrationBuilder.DropIndex(
                name: "IX_Donor_MaritalStatusId",
                table: "Donor");

            migrationBuilder.DropIndex(
                name: "IX_Donor_NationalityId",
                table: "Donor");

            migrationBuilder.DropIndex(
                name: "IX_Donor_ReferrerId",
                table: "Donor");

            migrationBuilder.DropIndex(
                name: "IX_Donor_ReligonId",
                table: "Donor");

            migrationBuilder.DropIndex(
                name: "IX_Attachment_DonorId",
                table: "Attachment");

            migrationBuilder.DropColumn(
                name: "AvailableServices",
                table: "Donor");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Donor");

            migrationBuilder.DropColumn(
                name: "BirthPlace",
                table: "Donor");

            migrationBuilder.DropColumn(
                name: "CharityJoinDate",
                table: "Donor");

            migrationBuilder.DropColumn(
                name: "CharityMainRoleId",
                table: "Donor");

            migrationBuilder.DropColumn(
                name: "CharityReferralSource",
                table: "Donor");

            migrationBuilder.DropColumn(
                name: "DonorType",
                table: "Donor");

            migrationBuilder.DropColumn(
                name: "EducationLevelId",
                table: "Donor");

            migrationBuilder.DropColumn(
                name: "EducationMajor",
                table: "Donor");

            migrationBuilder.DropColumn(
                name: "EducationStatusId",
                table: "Donor");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Donor");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "Donor");

            migrationBuilder.DropColumn(
                name: "HomeAddress",
                table: "Donor");

            migrationBuilder.DropColumn(
                name: "HomePhoneNumber",
                table: "Donor");

            migrationBuilder.DropColumn(
                name: "HouseCityId",
                table: "Donor");

            migrationBuilder.DropColumn(
                name: "HouseProvinceId",
                table: "Donor");

            migrationBuilder.DropColumn(
                name: "JobAddress",
                table: "Donor");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "Donor");

            migrationBuilder.DropColumn(
                name: "JobPhoneNumber",
                table: "Donor");

            migrationBuilder.DropColumn(
                name: "MaritalStatusId",
                table: "Donor");

            migrationBuilder.DropColumn(
                name: "MobileNumber",
                table: "Donor");

            migrationBuilder.DropColumn(
                name: "NationalityId",
                table: "Donor");

            migrationBuilder.DropColumn(
                name: "ReferrerId",
                table: "Donor");

            migrationBuilder.DropColumn(
                name: "ReligonId",
                table: "Donor");

            migrationBuilder.DropColumn(
                name: "DonorId",
                table: "Attachment");

            migrationBuilder.RenameColumn(
                name: "ShenasnamehNumber",
                table: "Donor",
                newName: "Address");

            migrationBuilder.AlterColumn<string>(
                name: "NationalCode",
                table: "Donor",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
