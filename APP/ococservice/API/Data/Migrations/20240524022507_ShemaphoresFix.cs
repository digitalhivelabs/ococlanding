using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class ShemaphoresFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QualityStandardItemRange_QualityStandardItems_QualityStandardItemQSIId",
                table: "QualityStandardItemRange");

            migrationBuilder.DropForeignKey(
                name: "FK_QualityStandardItemRange_Semaphore_SemaphoreId",
                table: "QualityStandardItemRange");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Semaphore",
                table: "Semaphore");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QualityStandardItemRange",
                table: "QualityStandardItemRange");

            migrationBuilder.RenameTable(
                name: "Semaphore",
                newName: "Semaphores");

            migrationBuilder.RenameTable(
                name: "QualityStandardItemRange",
                newName: "QualityStandardItemRanges");

            migrationBuilder.RenameIndex(
                name: "IX_QualityStandardItemRange_SemaphoreId",
                table: "QualityStandardItemRanges",
                newName: "IX_QualityStandardItemRanges_SemaphoreId");

            migrationBuilder.RenameIndex(
                name: "IX_QualityStandardItemRange_QualityStandardItemQSIId",
                table: "QualityStandardItemRanges",
                newName: "IX_QualityStandardItemRanges_QualityStandardItemQSIId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Semaphores",
                table: "Semaphores",
                column: "SemaphoreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QualityStandardItemRanges",
                table: "QualityStandardItemRanges",
                column: "QSIRId");

            migrationBuilder.AddForeignKey(
                name: "FK_QualityStandardItemRanges_QualityStandardItems_QualityStandardItemQSIId",
                table: "QualityStandardItemRanges",
                column: "QualityStandardItemQSIId",
                principalTable: "QualityStandardItems",
                principalColumn: "QSIId");

            migrationBuilder.AddForeignKey(
                name: "FK_QualityStandardItemRanges_Semaphores_SemaphoreId",
                table: "QualityStandardItemRanges",
                column: "SemaphoreId",
                principalTable: "Semaphores",
                principalColumn: "SemaphoreId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QualityStandardItemRanges_QualityStandardItems_QualityStandardItemQSIId",
                table: "QualityStandardItemRanges");

            migrationBuilder.DropForeignKey(
                name: "FK_QualityStandardItemRanges_Semaphores_SemaphoreId",
                table: "QualityStandardItemRanges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Semaphores",
                table: "Semaphores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QualityStandardItemRanges",
                table: "QualityStandardItemRanges");

            migrationBuilder.RenameTable(
                name: "Semaphores",
                newName: "Semaphore");

            migrationBuilder.RenameTable(
                name: "QualityStandardItemRanges",
                newName: "QualityStandardItemRange");

            migrationBuilder.RenameIndex(
                name: "IX_QualityStandardItemRanges_SemaphoreId",
                table: "QualityStandardItemRange",
                newName: "IX_QualityStandardItemRange_SemaphoreId");

            migrationBuilder.RenameIndex(
                name: "IX_QualityStandardItemRanges_QualityStandardItemQSIId",
                table: "QualityStandardItemRange",
                newName: "IX_QualityStandardItemRange_QualityStandardItemQSIId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Semaphore",
                table: "Semaphore",
                column: "SemaphoreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QualityStandardItemRange",
                table: "QualityStandardItemRange",
                column: "QSIRId");

            migrationBuilder.AddForeignKey(
                name: "FK_QualityStandardItemRange_QualityStandardItems_QualityStandardItemQSIId",
                table: "QualityStandardItemRange",
                column: "QualityStandardItemQSIId",
                principalTable: "QualityStandardItems",
                principalColumn: "QSIId");

            migrationBuilder.AddForeignKey(
                name: "FK_QualityStandardItemRange_Semaphore_SemaphoreId",
                table: "QualityStandardItemRange",
                column: "SemaphoreId",
                principalTable: "Semaphore",
                principalColumn: "SemaphoreId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
