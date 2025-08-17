using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketHunter.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class TradeStatusMaster : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TradeDirection",
                columns: table => new
                {
                    TradeDirectionId = table.Column<Guid>(type: "uuid", nullable: false),
                    TradeDirectionName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradeDirectionId", x => x.TradeDirectionId);
                });

            migrationBuilder.CreateTable(
                name: "TradeStatusMaster",
                columns: table => new
                {
                    TradeStatusId = table.Column<Guid>(type: "uuid", nullable: false),
                    TradeStatusName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradeStatusId", x => x.TradeStatusId);
                });

            migrationBuilder.CreateTable(
                name: "TradeMaster",
                columns: table => new
                {
                    TradeMasterId = table.Column<Guid>(type: "uuid", nullable: false),
                    InstrumentId = table.Column<Guid>(type: "uuid", nullable: false),
                    StrategyId = table.Column<Guid>(type: "uuid", nullable: false),
                    TradeDirectionId = table.Column<Guid>(type: "uuid", nullable: false),
                    EntryPrice = table.Column<double>(type: "double precision", precision: 10, scale: 2, nullable: false),
                    TargetPrice = table.Column<double>(type: "double precision", precision: 10, scale: 2, nullable: false),
                    StopLossPrice = table.Column<double>(type: "double precision", precision: 10, scale: 2, nullable: false),
                    PnL = table.Column<double>(type: "double precision", precision: 10, scale: 2, nullable: false),
                    FinalTradeStatusId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Remark = table.Column<string>(type: "text", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradeMasterId", x => x.TradeMasterId);
                    table.ForeignKey(
                        name: "FK_TradeMaster_InstrumentMaster_InstrumentId",
                        column: x => x.InstrumentId,
                        principalTable: "InstrumentMaster",
                        principalColumn: "InstrumentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TradeMaster_StrategyMaster_StrategyId",
                        column: x => x.StrategyId,
                        principalTable: "StrategyMaster",
                        principalColumn: "StrategyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TradeMaster_TradeDirection_TradeDirectionId",
                        column: x => x.TradeDirectionId,
                        principalTable: "TradeDirection",
                        principalColumn: "TradeDirectionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TradeMaster_TradeStatusMaster_FinalTradeStatusId",
                        column: x => x.FinalTradeStatusId,
                        principalTable: "TradeStatusMaster",
                        principalColumn: "TradeStatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TradeDetail",
                columns: table => new
                {
                    TradeDetailId = table.Column<Guid>(type: "uuid", nullable: false),
                    TradeMasterId = table.Column<Guid>(type: "uuid", nullable: false),
                    TradeStatusId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradeDetailId", x => x.TradeDetailId);
                    table.ForeignKey(
                        name: "FK_TradeDetail_TradeMaster_TradeMasterId",
                        column: x => x.TradeMasterId,
                        principalTable: "TradeMaster",
                        principalColumn: "TradeMasterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TradeDetail_TradeStatusMaster_Trade",
                        column: x => x.TradeStatusId,
                        principalTable: "TradeStatusMaster",
                        principalColumn: "TradeStatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TradeDetail_TradeMasterId",
                table: "TradeDetail",
                column: "TradeMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_TradeDetail_TradeStatusId",
                table: "TradeDetail",
                column: "TradeStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TradeMaster_FinalTradeStatusId",
                table: "TradeMaster",
                column: "FinalTradeStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TradeMaster_InstrumentId",
                table: "TradeMaster",
                column: "InstrumentId");

            migrationBuilder.CreateIndex(
                name: "IX_TradeMaster_StrategyId",
                table: "TradeMaster",
                column: "StrategyId");

            migrationBuilder.CreateIndex(
                name: "IX_TradeMaster_TradeDirectionId",
                table: "TradeMaster",
                column: "TradeDirectionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TradeDetail");

            migrationBuilder.DropTable(
                name: "TradeMaster");

            migrationBuilder.DropTable(
                name: "TradeDirection");

            migrationBuilder.DropTable(
                name: "TradeStatusMaster");
        }
    }
}
