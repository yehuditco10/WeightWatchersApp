using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeightWatchers.Data.Migrations
{
    public partial class initial : Migration
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

            migrationBuilder.CreateTable(
                name: "VerificationEmail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VerifyPassword = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    ExpiryDate = table.Column<DateTime>(nullable: false),
                    subscriberid = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerificationEmail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VerificationEmail_Subscriber_subscriberid",
                        column: x => x.subscriberid,
                        principalTable: "Subscriber",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateIndex(
                name: "IX_VerificationEmail_Email",
                table: "VerificationEmail",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VerificationEmail_subscriberid",
                table: "VerificationEmail",
                column: "subscriberid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.DropTable(
                name: "VerificationEmail");

            migrationBuilder.DropTable(
                name: "Subscriber");
        }
    }
}
