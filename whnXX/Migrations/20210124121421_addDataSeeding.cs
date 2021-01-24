using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace whnXX.Migrations
{
    public partial class addDataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TouristRoutes",
                columns: new[] { "Id", "CreateTime", "DepartureTime", "Description", "DiscountPresent", "Features", "Fees", "Notes", "OriginalPrice", "Title", "UpdateTime" },
                values: new object[] { new Guid("10d6a664-789e-41ae-8fe9-f7fb2ea4d099"), new DateTime(2021, 1, 24, 12, 14, 20, 935, DateTimeKind.Utc).AddTicks(1251), null, "ddd", null, null, null, null, 0m, "css", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TouristRoutes",
                keyColumn: "Id",
                keyValue: new Guid("10d6a664-789e-41ae-8fe9-f7fb2ea4d099"));
        }
    }
}
