using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TripPortal.Migrations
{
    /// <inheritdoc />
    public partial class Newest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Reservations_ReservationID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_ReservationID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ReservationID",
                table: "Students");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ReservationID",
                table: "Students",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_ReservationID",
                table: "Students",
                column: "ReservationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Reservations_ReservationID",
                table: "Students",
                column: "ReservationID",
                principalTable: "Reservations",
                principalColumn: "ReservationID");
        }
    }
}
