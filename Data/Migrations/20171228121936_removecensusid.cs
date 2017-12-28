using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace InformationServices.Data.Migrations
{
    public partial class removecensusid : Migration
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
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Censuses_CensusId",
                table: "Department",
                column: "CensusId",
                principalTable: "Censuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Censuses_CensusId",
                table: "Department");

            migrationBuilder.AlterColumn<int>(
                name: "CensusId",
                table: "Department",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Censuses_CensusId",
                table: "Department",
                column: "CensusId",
                principalTable: "Censuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
