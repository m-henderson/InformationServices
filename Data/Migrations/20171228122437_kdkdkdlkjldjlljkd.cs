using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace InformationServices.Data.Migrations
{
    public partial class kdkdkdlkjldjlljkd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Censuses_CensusId",
                table: "Department");

            migrationBuilder.AlterColumn<int>(
                name: "CensusId",
                table: "Department",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Censuses_CensusId",
                table: "Department",
                column: "CensusId",
                principalTable: "Censuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Censuses_CensusId",
                table: "Department");

            migrationBuilder.AlterColumn<int>(
                name: "CensusId",
                table: "Department",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Censuses_CensusId",
                table: "Department",
                column: "CensusId",
                principalTable: "Censuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
