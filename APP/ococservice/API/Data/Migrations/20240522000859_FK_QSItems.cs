using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class FK_QSItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QualityStandardItems_QualityStandards_QualityStandardQSId",
                table: "QualityStandardItems");

            migrationBuilder.DropIndex(
                name: "IX_QualityStandardItems_QualityStandardQSId",
                table: "QualityStandardItems");

            migrationBuilder.DropColumn(
                name: "QualityStandardQSId",
                table: "QualityStandardItems");

            migrationBuilder.CreateIndex(
                name: "IX_QualityStandardItems_QSId",
                table: "QualityStandardItems",
                column: "QSId");

            migrationBuilder.AddForeignKey(
                name: "FK_QualityStandardItems_QualityStandards_QSId",
                table: "QualityStandardItems",
                column: "QSId",
                principalTable: "QualityStandards",
                principalColumn: "QSId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QualityStandardItems_QualityStandards_QSId",
                table: "QualityStandardItems");

            migrationBuilder.DropIndex(
                name: "IX_QualityStandardItems_QSId",
                table: "QualityStandardItems");

            migrationBuilder.AddColumn<int>(
                name: "QualityStandardQSId",
                table: "QualityStandardItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_QualityStandardItems_QualityStandardQSId",
                table: "QualityStandardItems",
                column: "QualityStandardQSId");

            migrationBuilder.AddForeignKey(
                name: "FK_QualityStandardItems_QualityStandards_QualityStandardQSId",
                table: "QualityStandardItems",
                column: "QualityStandardQSId",
                principalTable: "QualityStandards",
                principalColumn: "QSId");
        }
    }
}
