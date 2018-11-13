using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DependerIO.Api.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", "'uuid-ossp', '', ''");

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Handlers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    ServiceId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Handlers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Handlers_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("a33b9430-6dd1-404c-80e6-fd2e5e275cff"), "Stripe eCommerce service", "Stripe" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("f346408d-fad1-4689-a21b-a62435482620"), "Intercom customer relationship management service", "Intercom" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("8aee5013-25fe-4d2c-b720-efbe83b33b5b"), "Mixpan analytics service", "Mixpanel" });

            migrationBuilder.InsertData(
                table: "Handlers",
                columns: new[] { "Id", "Name", "ServiceId" },
                values: new object[] { new Guid("cfa2fe87-c9fe-4e2c-9390-578354256735"), "Webhook", new Guid("a33b9430-6dd1-404c-80e6-fd2e5e275cff") });

            migrationBuilder.InsertData(
                table: "Handlers",
                columns: new[] { "Id", "Name", "ServiceId" },
                values: new object[] { new Guid("cf9fe886-95b2-44de-b880-6d30f1c9a881"), "Webhook", new Guid("f346408d-fad1-4689-a21b-a62435482620") });

            migrationBuilder.InsertData(
                table: "Handlers",
                columns: new[] { "Id", "Name", "ServiceId" },
                values: new object[] { new Guid("f4dad83c-69c5-4507-81db-bfcc998e5dae"), "Webhook", new Guid("8aee5013-25fe-4d2c-b720-efbe83b33b5b") });

            migrationBuilder.CreateIndex(
                name: "Idx_Handler_Name",
                table: "Handlers",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Handlers_ServiceId",
                table: "Handlers",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "Idx_Service_Name",
                table: "Services",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Handlers");

            migrationBuilder.DropTable(
                name: "Services");
        }
    }
}
