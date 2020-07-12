using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Measure.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Measure",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cardId = table.Column<int>(nullable: false),
                    weight = table.Column<float>(nullable: false, defaultValue: 0f),
                    date = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measure", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Measure");
        }
    }
}
