using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassificationItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Abbr = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassificationItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityStandards",
                columns: table => new
                {
                    QSId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Organization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Abbr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityStandards", x => x.QSId);
                });

            migrationBuilder.CreateTable(
                name: "Semaphore",
                columns: table => new
                {
                    SemaphoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hex = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semaphore", x => x.SemaphoreId);
                });

            migrationBuilder.CreateTable(
                name: "surveys",
                columns: table => new
                {
                    SurveyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationLatLon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_surveys", x => x.SurveyId);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    UnitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Abbr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaseUnitId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.UnitId);
                    table.ForeignKey(
                        name: "FK_Units_Units_BaseUnitId",
                        column: x => x.BaseUnitId,
                        principalTable: "Units",
                        principalColumn: "UnitId");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Job = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Conversions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Operator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Factor = table.Column<float>(type: "real", nullable: false),
                    Formula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceUnitId = table.Column<int>(type: "int", nullable: false),
                    TargetUnitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conversions_Units_SourceUnitId",
                        column: x => x.SourceUnitId,
                        principalTable: "Units",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Conversions_Units_TargetUnitId",
                        column: x => x.TargetUnitId,
                        principalTable: "Units",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    itemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Abbr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoreInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    ClassificationItemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.itemId);
                    table.ForeignKey(
                        name: "FK_Items_ClassificationItems_ClassificationItemId",
                        column: x => x.ClassificationItemId,
                        principalTable: "ClassificationItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Items_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QualityStandardItems",
                columns: table => new
                {
                    QSIId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QualityStandardQSId = table.Column<int>(type: "int", nullable: true),
                    LowerLim = table.Column<float>(type: "real", nullable: false),
                    UpperLim = table.Column<float>(type: "real", nullable: false),
                    LatLog = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QSId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    SemaphoreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityStandardItems", x => x.QSIId);
                    table.ForeignKey(
                        name: "FK_QualityStandardItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "itemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QualityStandardItems_QualityStandards_QualityStandardQSId",
                        column: x => x.QualityStandardQSId,
                        principalTable: "QualityStandards",
                        principalColumn: "QSId");
                    table.ForeignKey(
                        name: "FK_QualityStandardItems_Semaphore_SemaphoreId",
                        column: x => x.SemaphoreId,
                        principalTable: "Semaphore",
                        principalColumn: "SemaphoreId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QualityStandardItems_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "surveyItems",
                columns: table => new
                {
                    SIId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<float>(type: "real", nullable: false),
                    ValueBase = table.Column<float>(type: "real", nullable: false),
                    Method = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LabName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Responsible = table.Column<int>(type: "int", nullable: false),
                    Preferent = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SurveyId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    UnitBaseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_surveyItems", x => x.SIId);
                    table.ForeignKey(
                        name: "FK_surveyItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "itemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_surveyItems_Units_UnitBaseId",
                        column: x => x.UnitBaseId,
                        principalTable: "Units",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_surveyItems_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_surveyItems_surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "surveys",
                        principalColumn: "SurveyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conversions_SourceUnitId",
                table: "Conversions",
                column: "SourceUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Conversions_TargetUnitId",
                table: "Conversions",
                column: "TargetUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ClassificationItemId",
                table: "Items",
                column: "ClassificationItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_UnitId",
                table: "Items",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityStandardItems_ItemId",
                table: "QualityStandardItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityStandardItems_QualityStandardQSId",
                table: "QualityStandardItems",
                column: "QualityStandardQSId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityStandardItems_SemaphoreId",
                table: "QualityStandardItems",
                column: "SemaphoreId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityStandardItems_UnitId",
                table: "QualityStandardItems",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_surveyItems_ItemId",
                table: "surveyItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_surveyItems_SurveyId",
                table: "surveyItems",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_surveyItems_UnitBaseId",
                table: "surveyItems",
                column: "UnitBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_surveyItems_UnitId",
                table: "surveyItems",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_BaseUnitId",
                table: "Units",
                column: "BaseUnitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conversions");

            migrationBuilder.DropTable(
                name: "QualityStandardItems");

            migrationBuilder.DropTable(
                name: "surveyItems");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "QualityStandards");

            migrationBuilder.DropTable(
                name: "Semaphore");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "surveys");

            migrationBuilder.DropTable(
                name: "ClassificationItems");

            migrationBuilder.DropTable(
                name: "Units");
        }
    }
}
