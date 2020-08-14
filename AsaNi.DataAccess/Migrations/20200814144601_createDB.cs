using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AsaNi.DataAccess.Migrations
{
    public partial class createDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Area = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    IsNorthern = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    OwnerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Houses_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 1, "Mehrnoosh", "Developer", "09123333342" });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 2, "Ali", "Developer", "09113331355" });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 3, "Fateme", "Developer", "09125554478" });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "Area", "CreatedBy", "CreatedDateTime", "IsDeleted", "IsNorthern", "Name", "Number", "OwnerId", "UpdatedBy", "UpdatedDateTime" },
                values: new object[] { 1, "karaj", 0, "User", new DateTime(2020, 8, 14, 19, 16, 0, 876, DateTimeKind.Local).AddTicks(8894), false, false, "Ghasemi", "02102", 1, null, null });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "Area", "CreatedBy", "CreatedDateTime", "IsDeleted", "IsNorthern", "Name", "Number", "OwnerId", "UpdatedBy", "UpdatedDateTime" },
                values: new object[] { 2, "fardis", 0, "User", new DateTime(2020, 8, 14, 19, 16, 0, 880, DateTimeKind.Local).AddTicks(252), false, false, "Diba", "01240", 2, null, null });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "Area", "CreatedBy", "CreatedDateTime", "IsDeleted", "IsNorthern", "Name", "Number", "OwnerId", "UpdatedBy", "UpdatedDateTime" },
                values: new object[] { 3, "mehrshahr", 0, "User", new DateTime(2020, 8, 14, 19, 16, 0, 880, DateTimeKind.Local).AddTicks(1593), false, false, "Baran", "23105", 2, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Houses_OwnerId",
                table: "Houses",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Houses");

            migrationBuilder.DropTable(
                name: "Owners");
        }
    }
}
