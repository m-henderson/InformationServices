using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace InformationServices.Data.Migrations
{
    public partial class RemoteSomePRops : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Censuses_CensusId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_CensusId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "CensusId",
                table: "Departments");

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Censuses",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Department",
                table: "Censuses");

            migrationBuilder.AddColumn<int>(
                name: "CensusId",
                table: "Departments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_CensusId",
                table: "Departments",
                column: "CensusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Censuses_CensusId",
                table: "Departments",
                column: "CensusId",
                principalTable: "Censuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
