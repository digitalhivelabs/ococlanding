using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class QualityStandard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QualityStandardItems_Semaphore_SemaphoreId",
                table: "QualityStandardItems");

            migrationBuilder.DropIndex(
                name: "IX_QualityStandardItems_SemaphoreId",
                table: "QualityStandardItems");

            migrationBuilder.DropColumn(
                name: "LatLog",
                table: "QualityStandardItems");

            migrationBuilder.DropColumn(
                name: "LowerLim",
                table: "QualityStandardItems");

            migrationBuilder.DropColumn(
                name: "SemaphoreId",
                table: "QualityStandardItems");

            migrationBuilder.DropColumn(
                name: "UpperLim",
                table: "QualityStandardItems");

            migrationBuilder.AlterColumn<string>(
                name: "Distance",
                table: "SP_SubCategoriesAndPoints",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.CreateTable(
                name: "QualityStandardItemRange",
                columns: table => new
                {
                    QSIRId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LowerLim = table.Column<float>(type: "real", nullable: false),
                    UpperLim = table.Column<float>(type: "real", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QualityStandardItemQSIId = table.Column<int>(type: "int", nullable: true),
                    QSIId = table.Column<int>(type: "int", nullable: false),
                    SemaphoreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityStandardItemRange", x => x.QSIRId);
                    table.ForeignKey(
                        name: "FK_QualityStandardItemRange_QualityStandardItems_QualityStandardItemQSIId",
                        column: x => x.QualityStandardItemQSIId,
                        principalTable: "QualityStandardItems",
                        principalColumn: "QSIId");
                    table.ForeignKey(
                        name: "FK_QualityStandardItemRange_Semaphore_SemaphoreId",
                        column: x => x.SemaphoreId,
                        principalTable: "Semaphore",
                        principalColumn: "SemaphoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QualityStandardItemRange_QualityStandardItemQSIId",
                table: "QualityStandardItemRange",
                column: "QualityStandardItemQSIId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityStandardItemRange_SemaphoreId",
                table: "QualityStandardItemRange",
                column: "SemaphoreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QualityStandardItemRange");

            migrationBuilder.AlterColumn<float>(
                name: "Distance",
                table: "SP_SubCategoriesAndPoints",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LatLog",
                table: "QualityStandardItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "LowerLim",
                table: "QualityStandardItems",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "SemaphoreId",
                table: "QualityStandardItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "UpperLim",
                table: "QualityStandardItems",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateIndex(
                name: "IX_QualityStandardItems_SemaphoreId",
                table: "QualityStandardItems",
                column: "SemaphoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_QualityStandardItems_Semaphore_SemaphoreId",
                table: "QualityStandardItems",
                column: "SemaphoreId",
                principalTable: "Semaphore",
                principalColumn: "SemaphoreId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
