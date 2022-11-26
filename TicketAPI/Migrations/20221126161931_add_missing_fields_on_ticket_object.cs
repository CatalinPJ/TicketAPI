using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketAPI.Migrations
{
    /// <inheritdoc />
    public partial class addmissingfieldsonticketobject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Tickets",
                newName: "Subject");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ClosedOn",
                table: "Tickets",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "Customer",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClosedOn",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Customer",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "Subject",
                table: "Tickets",
                newName: "Name");
        }
    }
}
