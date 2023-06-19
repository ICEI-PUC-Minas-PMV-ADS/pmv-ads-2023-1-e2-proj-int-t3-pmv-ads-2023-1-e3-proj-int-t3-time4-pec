using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaHospitalar.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class _01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "DataNascimento" },
                values: new object[] { new DateTime(2023, 6, 18, 21, 26, 33, 599, DateTimeKind.Local).AddTicks(7363), new DateTime(2023, 6, 18, 21, 26, 33, 599, DateTimeKind.Local).AddTicks(7354) });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "DataNascimento" },
                values: new object[] { new DateTime(2023, 6, 18, 21, 26, 33, 599, DateTimeKind.Local).AddTicks(7365), new DateTime(2023, 6, 18, 21, 26, 33, 599, DateTimeKind.Local).AddTicks(7364) });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "DataNascimento" },
                values: new object[] { new DateTime(2023, 6, 18, 21, 26, 33, 599, DateTimeKind.Local).AddTicks(7367), new DateTime(2023, 6, 18, 21, 26, 33, 599, DateTimeKind.Local).AddTicks(7366) });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "DataNascimento" },
                values: new object[] { new DateTime(2023, 6, 18, 21, 26, 33, 599, DateTimeKind.Local).AddTicks(7368), new DateTime(2023, 6, 18, 21, 26, 33, 599, DateTimeKind.Local).AddTicks(7368) });

            migrationBuilder.UpdateData(
                table: "Prontuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 6, 18, 21, 26, 33, 599, DateTimeKind.Local).AddTicks(7442));

            migrationBuilder.UpdateData(
                table: "Prontuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 6, 18, 21, 26, 33, 599, DateTimeKind.Local).AddTicks(7443));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "DataNascimento" },
                values: new object[] { new DateTime(2023, 6, 18, 19, 7, 18, 808, DateTimeKind.Local).AddTicks(8140), new DateTime(2023, 6, 18, 19, 7, 18, 808, DateTimeKind.Local).AddTicks(8131) });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "DataNascimento" },
                values: new object[] { new DateTime(2023, 6, 18, 19, 7, 18, 808, DateTimeKind.Local).AddTicks(8141), new DateTime(2023, 6, 18, 19, 7, 18, 808, DateTimeKind.Local).AddTicks(8141) });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "DataNascimento" },
                values: new object[] { new DateTime(2023, 6, 18, 19, 7, 18, 808, DateTimeKind.Local).AddTicks(8143), new DateTime(2023, 6, 18, 19, 7, 18, 808, DateTimeKind.Local).AddTicks(8142) });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "DataNascimento" },
                values: new object[] { new DateTime(2023, 6, 18, 19, 7, 18, 808, DateTimeKind.Local).AddTicks(8144), new DateTime(2023, 6, 18, 19, 7, 18, 808, DateTimeKind.Local).AddTicks(8144) });

            migrationBuilder.UpdateData(
                table: "Prontuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 6, 18, 19, 7, 18, 808, DateTimeKind.Local).AddTicks(8216));

            migrationBuilder.UpdateData(
                table: "Prontuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 6, 18, 19, 7, 18, 808, DateTimeKind.Local).AddTicks(8217));
        }
    }
}
