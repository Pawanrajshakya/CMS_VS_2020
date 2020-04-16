using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence_Layer.Migrations
{
    public partial class InitalCreateDB_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Businesses",
                columns: new[] { "Id", "Address1", "Address2", "CreatedBy", "CreatedDate", "Description", "IsActive", "IsVisible", "LastModifiedBy", "LastModifiedDate", "Name", "State", "ZipCode" },
                values: new object[] { 1, "Address 1", "Address 2", 0, new DateTime(2020, 4, 14, 17, 14, 38, 832, DateTimeKind.Local).AddTicks(8550), null, true, true, 0, new DateTime(2020, 4, 14, 17, 14, 38, 832, DateTimeKind.Local).AddTicks(8570), "Business Name", "zz", "zzzzz" });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "IsActive", "IsVisible", "LastModifiedBy", "LastModifiedDate", "Order" },
                values: new object[] { 1, 0, new DateTime(2020, 4, 14, 17, 14, 38, 833, DateTimeKind.Local).AddTicks(2360), "New Group", true, true, 0, new DateTime(2020, 4, 14, 17, 14, 38, 833, DateTimeKind.Local).AddTicks(2370), 0 });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2020, 4, 14, 17, 14, 38, 815, DateTimeKind.Local).AddTicks(1770), new DateTime(2020, 4, 14, 17, 14, 38, 830, DateTimeKind.Local).AddTicks(7400) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2020, 4, 14, 17, 14, 38, 831, DateTimeKind.Local).AddTicks(1400), new DateTime(2020, 4, 14, 17, 14, 38, 831, DateTimeKind.Local).AddTicks(1430) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2020, 4, 14, 17, 14, 38, 831, DateTimeKind.Local).AddTicks(1510), new DateTime(2020, 4, 14, 17, 14, 38, 831, DateTimeKind.Local).AddTicks(1510) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Businesses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2020, 4, 14, 17, 5, 35, 50, DateTimeKind.Local).AddTicks(5650), new DateTime(2020, 4, 14, 17, 5, 35, 68, DateTimeKind.Local).AddTicks(6270) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2020, 4, 14, 17, 5, 35, 68, DateTimeKind.Local).AddTicks(9880), new DateTime(2020, 4, 14, 17, 5, 35, 68, DateTimeKind.Local).AddTicks(9920) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2020, 4, 14, 17, 5, 35, 68, DateTimeKind.Local).AddTicks(9990), new DateTime(2020, 4, 14, 17, 5, 35, 69, DateTimeKind.Local) });
        }
    }
}
