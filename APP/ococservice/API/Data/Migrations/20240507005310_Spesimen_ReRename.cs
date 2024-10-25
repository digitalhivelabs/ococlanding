using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class Spesimen_ReRename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpesimentItems");

            migrationBuilder.DropTable(
                name: "Spesiments");

            migrationBuilder.CreateTable(
                name: "Spesimens",
                columns: table => new
                {
                    SpesimenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpesimenDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PointId = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spesimens", x => x.SpesimenId);
                    table.ForeignKey(
                        name: "FK_Spesimens_Points_PointId",
                        column: x => x.PointId,
                        principalTable: "Points",
                        principalColumn: "PointId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Spesimens_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SpesimenItems",
                columns: table => new
                {
                    SIId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<float>(type: "real", nullable: false),
                    ValueBase = table.Column<float>(type: "real", nullable: false),
                    Method = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LabName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Responsible = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Preferent = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpesimenId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    UnitBaseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpesimenItems", x => x.SIId);
                    table.ForeignKey(
                        name: "FK_SpesimenItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "itemId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SpesimenItems_Spesimens_SpesimenId",
                        column: x => x.SpesimenId,
                        principalTable: "Spesimens",
                        principalColumn: "SpesimenId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SpesimenItems_Units_UnitBaseId",
                        column: x => x.UnitBaseId,
                        principalTable: "Units",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpesimenItems_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpesimenItems_ItemId",
                table: "SpesimenItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SpesimenItems_SpesimenId",
                table: "SpesimenItems",
                column: "SpesimenId");

            migrationBuilder.CreateIndex(
                name: "IX_SpesimenItems_UnitBaseId",
                table: "SpesimenItems",
                column: "UnitBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_SpesimenItems_UnitId",
                table: "SpesimenItems",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Spesimens_CreatedById",
                table: "Spesimens",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Spesimens_PointId",
                table: "Spesimens",
                column: "PointId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpesimenItems");

            migrationBuilder.DropTable(
                name: "Spesimens");

            migrationBuilder.CreateTable(
                name: "Spesiments",
                columns: table => new
                {
                    SpesimentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    PointId = table.Column<int>(type: "int", nullable: false),
                    CDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpesimentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spesiments", x => x.SpesimentId);
                    table.ForeignKey(
                        name: "FK_Spesiments_Points_PointId",
                        column: x => x.PointId,
                        principalTable: "Points",
                        principalColumn: "PointId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Spesiments_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SpesimentItems",
                columns: table => new
                {
                    SIId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    SpesimentId = table.Column<int>(type: "int", nullable: false),
                    UnitBaseId = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    LabName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Method = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Preferent = table.Column<bool>(type: "bit", nullable: false),
                    Responsible = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<float>(type: "real", nullable: false),
                    ValueBase = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpesimentItems", x => x.SIId);
                    table.ForeignKey(
                        name: "FK_SpesimentItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "itemId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SpesimentItems_Spesiments_SpesimentId",
                        column: x => x.SpesimentId,
                        principalTable: "Spesiments",
                        principalColumn: "SpesimentId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SpesimentItems_Units_UnitBaseId",
                        column: x => x.UnitBaseId,
                        principalTable: "Units",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpesimentItems_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpesimentItems_ItemId",
                table: "SpesimentItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SpesimentItems_SpesimentId",
                table: "SpesimentItems",
                column: "SpesimentId");

            migrationBuilder.CreateIndex(
                name: "IX_SpesimentItems_UnitBaseId",
                table: "SpesimentItems",
                column: "UnitBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_SpesimentItems_UnitId",
                table: "SpesimentItems",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Spesiments_CreatedById",
                table: "Spesiments",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Spesiments_PointId",
                table: "Spesiments",
                column: "PointId");
        }
    }
}
