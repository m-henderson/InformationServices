using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace InformationServices.Data.Migrations
{
    public partial class AddStatusNavigationProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TicketId",
                table: "Statuses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Statuses_TicketId",
                table: "Statuses",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Statuses_Tickets_TicketId",
                table: "Statuses",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Statuses_Tickets_TicketId",
                table: "Statuses");

            migrationBuilder.DropIndex(
                name: "IX_Statuses_TicketId",
                table: "Statuses");

            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "Statuses");
        }
    }
}
