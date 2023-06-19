using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaHospitalar.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "DataNascimento" },
                values: new object[] { new DateTime(2023, 6, 11, 22, 27, 12, 755, DateTimeKind.Local).AddTicks(8795), new DateTime(2023, 6, 11, 22, 27, 12, 755, DateTimeKind.Local).AddTicks(8787) });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "DataNascimento" },
                values: new object[] { new DateTime(2023, 6, 11, 22, 27, 12, 755, DateTimeKind.Local).AddTicks(8796), new DateTime(2023, 6, 11, 22, 27, 12, 755, DateTimeKind.Local).AddTicks(8796) });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "DataNascimento" },
                values: new object[] { new DateTime(2023, 6, 11, 22, 27, 12, 755, DateTimeKind.Local).AddTicks(8798), new DateTime(2023, 6, 11, 22, 27, 12, 755, DateTimeKind.Local).AddTicks(8797) });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "DataNascimento" },
                values: new object[] { new DateTime(2023, 6, 11, 22, 27, 12, 755, DateTimeKind.Local).AddTicks(8799), new DateTime(2023, 6, 11, 22, 27, 12, 755, DateTimeKind.Local).AddTicks(8799) });

            migrationBuilder.UpdateData(
                table: "Prontuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 6, 11, 22, 27, 12, 755, DateTimeKind.Local).AddTicks(8874));

            migrationBuilder.UpdateData(
                table: "Prontuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 6, 11, 22, 27, 12, 755, DateTimeKind.Local).AddTicks(8875));
        }
    }
}
