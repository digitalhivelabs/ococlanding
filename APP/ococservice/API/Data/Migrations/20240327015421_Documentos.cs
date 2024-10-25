using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class Documentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_surveyItems_Items_ItemId",
                table: "surveyItems");

            migrationBuilder.DropForeignKey(
                name: "FK_surveyItems_Units_UnitBaseId",
                table: "surveyItems");

            migrationBuilder.DropForeignKey(
                name: "FK_surveyItems_Units_UnitId",
                table: "surveyItems");

            migrationBuilder.DropForeignKey(
                name: "FK_surveyItems_surveys_SurveyId",
                table: "surveyItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_surveys",
                table: "surveys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_surveyItems",
                table: "surveyItems");

            migrationBuilder.RenameTable(
                name: "surveys",
                newName: "Surveys");

            migrationBuilder.RenameTable(
                name: "surveyItems",
                newName: "SurveyItems");

            migrationBuilder.RenameIndex(
                name: "IX_surveyItems_UnitId",
                table: "SurveyItems",
                newName: "IX_SurveyItems_UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_surveyItems_UnitBaseId",
                table: "SurveyItems",
                newName: "IX_SurveyItems_UnitBaseId");

            migrationBuilder.RenameIndex(
                name: "IX_surveyItems_SurveyId",
                table: "SurveyItems",
                newName: "IX_SurveyItems_SurveyId");

            migrationBuilder.RenameIndex(
                name: "IX_surveyItems_ItemId",
                table: "SurveyItems",
                newName: "IX_SurveyItems_ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Surveys",
                table: "Surveys",
                column: "SurveyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SurveyItems",
                table: "SurveyItems",
                column: "SIId");

            migrationBuilder.CreateTable(
                name: "Documentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Abstrac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPublisher = table.Column<bool>(type: "bit", nullable: false),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserUploaderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documentos_Users_UserUploaderId",
                        column: x => x.UserUploaderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_UserUploaderId",
                table: "Documentos",
                column: "UserUploaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyItems_Items_ItemId",
                table: "SurveyItems",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "itemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyItems_Surveys_SurveyId",
                table: "SurveyItems",
                column: "SurveyId",
                principalTable: "Surveys",
                principalColumn: "SurveyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyItems_Units_UnitBaseId",
                table: "SurveyItems",
                column: "UnitBaseId",
                principalTable: "Units",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyItems_Units_UnitId",
                table: "SurveyItems",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SurveyItems_Items_ItemId",
                table: "SurveyItems");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyItems_Surveys_SurveyId",
                table: "SurveyItems");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyItems_Units_UnitBaseId",
                table: "SurveyItems");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyItems_Units_UnitId",
                table: "SurveyItems");

            migrationBuilder.DropTable(
                name: "Documentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Surveys",
                table: "Surveys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SurveyItems",
                table: "SurveyItems");

            migrationBuilder.RenameTable(
                name: "Surveys",
                newName: "surveys");

            migrationBuilder.RenameTable(
                name: "SurveyItems",
                newName: "surveyItems");

            migrationBuilder.RenameIndex(
                name: "IX_SurveyItems_UnitId",
                table: "surveyItems",
                newName: "IX_surveyItems_UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_SurveyItems_UnitBaseId",
                table: "surveyItems",
                newName: "IX_surveyItems_UnitBaseId");

            migrationBuilder.RenameIndex(
                name: "IX_SurveyItems_SurveyId",
                table: "surveyItems",
                newName: "IX_surveyItems_SurveyId");

            migrationBuilder.RenameIndex(
                name: "IX_SurveyItems_ItemId",
                table: "surveyItems",
                newName: "IX_surveyItems_ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_surveys",
                table: "surveys",
                column: "SurveyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_surveyItems",
                table: "surveyItems",
                column: "SIId");

            migrationBuilder.AddForeignKey(
                name: "FK_surveyItems_Items_ItemId",
                table: "surveyItems",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "itemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_surveyItems_Units_UnitBaseId",
                table: "surveyItems",
                column: "UnitBaseId",
                principalTable: "Units",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_surveyItems_Units_UnitId",
                table: "surveyItems",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_surveyItems_surveys_SurveyId",
                table: "surveyItems",
                column: "SurveyId",
                principalTable: "surveys",
                principalColumn: "SurveyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
