using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketHunter.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class FinalMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StrategyMaster_TimeFrameMaster",
                table: "StrategyMaster");

            migrationBuilder.AddForeignKey(
                name: "FK_StrategyMaster_TimeFrame_TimeFrameId",
                table: "StrategyMaster",
                column: "TimeFrameId",
                principalTable: "TimeFrameMaster",
                principalColumn: "TimeFrameId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StrategyMaster_TimeFrame_TimeFrameId",
                table: "StrategyMaster");

            migrationBuilder.AddForeignKey(
                name: "FK_StrategyMaster_TimeFrameMaster",
                table: "StrategyMaster",
                column: "TimeFrameId",
                principalTable: "TimeFrameMaster",
                principalColumn: "TimeFrameId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
