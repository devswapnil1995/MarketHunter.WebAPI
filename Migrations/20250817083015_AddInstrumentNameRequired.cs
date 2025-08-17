using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketHunter.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddInstrumentNameRequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InstrumentMaster",
                columns: table => new
                {
                    InstrumentId = table.Column<Guid>(type: "uuid", nullable: false),
                    InstrumentName = table.Column<string>(type: "text", nullable: false),
                    InstrumentKey = table.Column<string>(type: "text", nullable: true),
                    InstrumentCode = table.Column<string>(type: "text", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstrumentId", x => x.InstrumentId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstrumentMaster");
        }
    }
}
