using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _7Price.Migrations
{
    /// <inheritdoc />
    public partial class NewsDateUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "NewsDate",
                table: "News",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewsDate",
                table: "News");
        }
    }
}
