using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketHunter.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class TimeFrameMaster : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TimeFrameMaster",
                columns: table => new
                {
                    TimeFrameId = table.Column<Guid>(type: "uuid", nullable: false),
                    TimeFrameName = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeFrameId", x => x.TimeFrameId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeFrameMaster");
        }
    }
}
