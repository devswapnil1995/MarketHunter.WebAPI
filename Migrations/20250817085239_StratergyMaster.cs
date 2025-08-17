using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketHunter.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class StratergyMaster : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StrategyMaster",
                columns: table => new
                {
                    StrategyId = table.Column<Guid>(type: "uuid", nullable: false),
                    StrategyName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    StrategyDesc = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    TimeFrameId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrategyId", x => x.StrategyId);
                    table.ForeignKey(
                        name: "FK_StrategyMaster_TimeFrameMaster",
                        column: x => x.TimeFrameId,
                        principalTable: "TimeFrameMaster",
                        principalColumn: "TimeFrameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StrategyMaster_TimeFrameId",
                table: "StrategyMaster",
                column: "TimeFrameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StrategyMaster");
        }
    }
}
