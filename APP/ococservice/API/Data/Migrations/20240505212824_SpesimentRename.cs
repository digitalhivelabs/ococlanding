using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class SpesimentRename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Category_CategoryId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Place_State_StateId",
                table: "Place");

            migrationBuilder.DropForeignKey(
                name: "FK_Place_SubCategory_SubCategoryId",
                table: "Place");

            migrationBuilder.DropForeignKey(
                name: "FK_Point_Place_PlaceId",
                table: "Point");

            migrationBuilder.DropForeignKey(
                name: "FK_State_Country_CountryCode",
                table: "State");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategory_Category_CategoryId",
                table: "SubCategory");

            migrationBuilder.DropTable(
                name: "SurveyItems");

            migrationBuilder.DropTable(
                name: "Surveys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubCategory",
                table: "SubCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_State",
                table: "State");

            migrationBuilder.DropIndex(
                name: "IX_State_CountryCode",
                table: "State");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Point",
                table: "Point");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Place",
                table: "Place");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Country",
                table: "Country");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "State");

            // migrationBuilder.DropColumn(
            //     name: "CountryCode1",
            //     table: "State");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Country");

            migrationBuilder.RenameTable(
                name: "SubCategory",
                newName: "SubCategories");

            migrationBuilder.RenameTable(
                name: "State",
                newName: "States");

            migrationBuilder.RenameTable(
                name: "Point",
                newName: "Points");

            migrationBuilder.RenameTable(
                name: "Place",
                newName: "Places");

            migrationBuilder.RenameTable(
                name: "Country",
                newName: "Countries");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_SubCategory_CategoryId",
                table: "SubCategories",
                newName: "IX_SubCategories_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Point_PlaceId",
                table: "Points",
                newName: "IX_Points_PlaceId");

            migrationBuilder.RenameColumn(
                name: "LatLon",
                table: "Places",
                newName: "URLImage");

            migrationBuilder.RenameIndex(
                name: "IX_Place_SubCategoryId",
                table: "Places",
                newName: "IX_Places_SubCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Place_StateId",
                table: "Places",
                newName: "IX_Places_StateId");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "States",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Lat",
                table: "Points",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Lon",
                table: "Points",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Lat",
                table: "Places",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Lon",
                table: "Places",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<string>(
                name: "CountryCode",
                table: "Countries",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Countries",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubCategories",
                table: "SubCategories",
                column: "SubCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_States",
                table: "States",
                column: "StateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Points",
                table: "Points",
                column: "PointId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Places",
                table: "Places",
                column: "PlaceID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countries",
                table: "Countries",
                column: "CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "CategoryId");

            migrationBuilder.CreateTable(
                name: "Spesiments",
                columns: table => new
                {
                    SpesimentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpesimentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PointId = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false)
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
                    Value = table.Column<float>(type: "real", nullable: false),
                    ValueBase = table.Column<float>(type: "real", nullable: false),
                    Method = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LabName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Responsible = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Preferent = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpesimentId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    UnitBaseId = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_States_CountryId",
                table: "States",
                column: "CountryId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Categories_CategoryId",
                table: "Items",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Places_States_StateId",
                table: "Places",
                column: "StateId",
                principalTable: "States",
                principalColumn: "StateId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Places_SubCategories_SubCategoryId",
                table: "Places",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "SubCategoryId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Points_Places_PlaceId",
                table: "Points",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "PlaceID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_States_Countries_CountryId",
                table: "States",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategories_Categories_CategoryId",
                table: "SubCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Categories_CategoryId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Places_States_StateId",
                table: "Places");

            migrationBuilder.DropForeignKey(
                name: "FK_Places_SubCategories_SubCategoryId",
                table: "Places");

            migrationBuilder.DropForeignKey(
                name: "FK_Points_Places_PlaceId",
                table: "Points");

            migrationBuilder.DropForeignKey(
                name: "FK_States_Countries_CountryId",
                table: "States");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategories_Categories_CategoryId",
                table: "SubCategories");

            migrationBuilder.DropTable(
                name: "SpesimentItems");

            migrationBuilder.DropTable(
                name: "Spesiments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubCategories",
                table: "SubCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_States",
                table: "States");

            migrationBuilder.DropIndex(
                name: "IX_States_CountryId",
                table: "States");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Points",
                table: "Points");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Places",
                table: "Places");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                table: "Countries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "States");

            migrationBuilder.DropColumn(
                name: "Lat",
                table: "Points");

            migrationBuilder.DropColumn(
                name: "Lon",
                table: "Points");

            migrationBuilder.DropColumn(
                name: "Lat",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "Lon",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Countries");

            migrationBuilder.RenameTable(
                name: "SubCategories",
                newName: "SubCategory");

            migrationBuilder.RenameTable(
                name: "States",
                newName: "State");

            migrationBuilder.RenameTable(
                name: "Points",
                newName: "Point");

            migrationBuilder.RenameTable(
                name: "Places",
                newName: "Place");

            migrationBuilder.RenameTable(
                name: "Countries",
                newName: "Country");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameIndex(
                name: "IX_SubCategories_CategoryId",
                table: "SubCategory",
                newName: "IX_SubCategory_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Points_PlaceId",
                table: "Point",
                newName: "IX_Point_PlaceId");

            migrationBuilder.RenameColumn(
                name: "URLImage",
                table: "Place",
                newName: "LatLon");

            migrationBuilder.RenameIndex(
                name: "IX_Places_SubCategoryId",
                table: "Place",
                newName: "IX_Place_SubCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Places_StateId",
                table: "Place",
                newName: "IX_Place_StateId");

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "State",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true);

            // migrationBuilder.AddColumn<string>(
            //     name: "CountryCode1",
            //     table: "State",
            //     type: "nvarchar(3)",
            //     nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CountryCode",
                table: "Country",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Country",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubCategory",
                table: "SubCategory",
                column: "SubCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_State",
                table: "State",
                column: "StateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Point",
                table: "Point",
                column: "PointId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Place",
                table: "Place",
                column: "PlaceID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Country",
                table: "Country",
                column: "CountryCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "CategoryId");

            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    SurveyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    PointId = table.Column<int>(type: "int", nullable: false),
                    CDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SurveyDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.SurveyId);
                    table.ForeignKey(
                        name: "FK_Surveys_Point_PointId",
                        column: x => x.PointId,
                        principalTable: "Point",
                        principalColumn: "PointId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Surveys_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SurveyItems",
                columns: table => new
                {
                    SIId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    SurveyId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_SurveyItems", x => x.SIId);
                    table.ForeignKey(
                        name: "FK_SurveyItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "itemId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SurveyItems_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "SurveyId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SurveyItems_Units_UnitBaseId",
                        column: x => x.UnitBaseId,
                        principalTable: "Units",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SurveyItems_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_State_CountryCode",
                table: "State",
                column: "CountryCode");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyItems_ItemId",
                table: "SurveyItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyItems_SurveyId",
                table: "SurveyItems",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyItems_UnitBaseId",
                table: "SurveyItems",
                column: "UnitBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyItems_UnitId",
                table: "SurveyItems",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_CreatedById",
                table: "Surveys",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_PointId",
                table: "Surveys",
                column: "PointId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Category_CategoryId",
                table: "Items",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Place_State_StateId",
                table: "Place",
                column: "StateId",
                principalTable: "State",
                principalColumn: "StateId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Place_SubCategory_SubCategoryId",
                table: "Place",
                column: "SubCategoryId",
                principalTable: "SubCategory",
                principalColumn: "SubCategoryId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Point_Place_PlaceId",
                table: "Point",
                column: "PlaceId",
                principalTable: "Place",
                principalColumn: "PlaceID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_State_Country_CountryCode",
                table: "State",
                column: "CountryCode",
                principalTable: "Country",
                principalColumn: "CountryCode");

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategory_Category_CategoryId",
                table: "SubCategory",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
