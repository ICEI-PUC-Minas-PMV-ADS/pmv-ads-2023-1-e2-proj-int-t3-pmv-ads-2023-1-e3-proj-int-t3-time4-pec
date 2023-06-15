using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaHospitalar.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class M002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Condutas",
                table: "Prontuarios",
                newName: "Conduta");

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

            migrationBuilder.CreateIndex(
                name: "IX_Prontuarios_PacienteId",
                table: "Prontuarios",
                column: "PacienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prontuarios_Pacientes_PacienteId",
                table: "Prontuarios",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prontuarios_Pacientes_PacienteId",
                table: "Prontuarios");

            migrationBuilder.DropIndex(
                name: "IX_Prontuarios_PacienteId",
                table: "Prontuarios");

            migrationBuilder.RenameColumn(
                name: "Conduta",
                table: "Prontuarios",
                newName: "Condutas");

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "DataNascimento" },
                values: new object[] { new DateTime(2023, 2, 7, 18, 37, 20, 919, DateTimeKind.Local).AddTicks(4656), new DateTime(2023, 2, 7, 18, 37, 20, 919, DateTimeKind.Local).AddTicks(4641) });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "DataNascimento" },
                values: new object[] { new DateTime(2023, 2, 7, 18, 37, 20, 919, DateTimeKind.Local).AddTicks(4659), new DateTime(2023, 2, 7, 18, 37, 20, 919, DateTimeKind.Local).AddTicks(4659) });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "DataNascimento" },
                values: new object[] { new DateTime(2023, 2, 7, 18, 37, 20, 919, DateTimeKind.Local).AddTicks(4660), new DateTime(2023, 2, 7, 18, 37, 20, 919, DateTimeKind.Local).AddTicks(4660) });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "DataNascimento" },
                values: new object[] { new DateTime(2023, 2, 7, 18, 37, 20, 919, DateTimeKind.Local).AddTicks(4662), new DateTime(2023, 2, 7, 18, 37, 20, 919, DateTimeKind.Local).AddTicks(4661) });

            migrationBuilder.UpdateData(
                table: "Prontuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 2, 7, 18, 37, 20, 919, DateTimeKind.Local).AddTicks(4769));

            migrationBuilder.UpdateData(
                table: "Prontuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 2, 7, 18, 37, 20, 919, DateTimeKind.Local).AddTicks(4775));
        }
    }
}
