using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desgination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JoiningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PinCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "City", "Country", "CreateDate", "Desgination", "Guid", "ImagePath", "JoiningDate", "Name", "PinCode", "State", "Street" },
                values: new object[] { 1, "test1", "", "India", new DateTime(2022, 6, 23, 7, 19, 37, 503, DateTimeKind.Local).AddTicks(288), "Test Engineer", new Guid("a699939f-65fa-4de9-9599-bd9fff9e2e3c"), "", new DateTime(2012, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "", "", "" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "City", "Country", "CreateDate", "Desgination", "Guid", "ImagePath", "JoiningDate", "Name", "PinCode", "State", "Street" },
                values: new object[] { 2, "test1", "", "India", new DateTime(2022, 6, 23, 7, 19, 37, 503, DateTimeKind.Local).AddTicks(300), "PMO", new Guid("355f110d-beb0-4704-92f1-8cf78cc0f03a"), "", new DateTime(2019, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luther", "", "", "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
