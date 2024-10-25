using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class DocumentUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documentos_Users_UserUploaderId",
                table: "Documentos");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Users",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublicationDate",
                table: "Documentos",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "MDate",
                table: "Documentos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Documentos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_UserId",
                table: "Documentos",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documentos_Users_UserId",
                table: "Documentos",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documentos_Users_UserUploaderId",
                table: "Documentos",
                column: "UserUploaderId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documentos_Users_UserId",
                table: "Documentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Documentos_Users_UserUploaderId",
                table: "Documentos");

            migrationBuilder.DropIndex(
                name: "IX_Documentos_UserId",
                table: "Documentos");

            migrationBuilder.DropColumn(
                name: "MDate",
                table: "Documentos");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Documentos");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublicationDate",
                table: "Documentos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Documentos_Users_UserUploaderId",
                table: "Documentos",
                column: "UserUploaderId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
