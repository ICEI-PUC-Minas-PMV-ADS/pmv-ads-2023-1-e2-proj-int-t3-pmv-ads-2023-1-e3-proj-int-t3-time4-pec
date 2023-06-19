using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaHospitalar.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class _02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "DataNascimento" },
                values: new object[] { new DateTime(2023, 6, 18, 21, 29, 51, 11, DateTimeKind.Local).AddTicks(1272), new DateTime(2023, 6, 18, 21, 29, 51, 11, DateTimeKind.Local).AddTicks(1264) });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "DataNascimento" },
                values: new object[] { new DateTime(2023, 6, 18, 21, 29, 51, 11, DateTimeKind.Local).AddTicks(1274), new DateTime(2023, 6, 18, 21, 29, 51, 11, DateTimeKind.Local).AddTicks(1273) });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "DataNascimento" },
                values: new object[] { new DateTime(2023, 6, 18, 21, 29, 51, 11, DateTimeKind.Local).AddTicks(1275), new DateTime(2023, 6, 18, 21, 29, 51, 11, DateTimeKind.Local).AddTicks(1275) });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "DataNascimento" },
                values: new object[] { new DateTime(2023, 6, 18, 21, 29, 51, 11, DateTimeKind.Local).AddTicks(1277), new DateTime(2023, 6, 18, 21, 29, 51, 11, DateTimeKind.Local).AddTicks(1276) });

            migrationBuilder.UpdateData(
                table: "Prontuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 6, 18, 21, 29, 51, 11, DateTimeKind.Local).AddTicks(1400));

            migrationBuilder.UpdateData(
                table: "Prontuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 6, 18, 21, 29, 51, 11, DateTimeKind.Local).AddTicks(1402));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
