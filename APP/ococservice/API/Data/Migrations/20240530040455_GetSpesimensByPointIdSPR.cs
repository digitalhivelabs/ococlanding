using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class GetSpesimensByPointIdSPR : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SP_SpesimensByPointIdSPR",
                columns: table => new
                {
                    LabName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Method = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitAbbr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QS_Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QS_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QS_Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QS_Hex = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SP_SpesimensByPointIdSPR");
        }
    }
}
