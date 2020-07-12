using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeightWatchers.Data.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subscriber",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    firstName = table.Column<string>(nullable: false),
                    lastName = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriber", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subscriberId = table.Column<Guid>(nullable: false),
                    openDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    BMI = table.Column<float>(nullable: false, defaultValue: 0f),
                    height = table.Column<float>(nullable: false),
                    weight = table.Column<float>(nullable: false, defaultValue: 0f),
                    updateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.id);
                    table.ForeignKey(
                        name: "FK_Card_Subscriber_subscriberId",
                        column: x => x.subscriberId,
                        principalTable: "Subscriber",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Card_subscriberId",
                table: "Card",
                column: "subscriberId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subscriber_email",
                table: "Subscriber",
                column: "email",
                unique: true,
                filter: "[email] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.DropTable(
                name: "Subscriber");
        }
    }
}
