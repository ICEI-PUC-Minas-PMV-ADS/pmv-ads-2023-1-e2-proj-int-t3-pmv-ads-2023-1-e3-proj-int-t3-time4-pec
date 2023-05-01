using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SistemaHospitalar.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Tabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Convenios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Convenios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EspecialidadesMedicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspecialidadesMedicas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Naturalidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sexo = table.Column<int>(type: "int", nullable: false),
                    Perfil = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PessoaId = table.Column<int>(type: "int", nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rua = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UF = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enderecos_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EspecialidadeId = table.Column<int>(type: "int", nullable: false),
                    PessoaId = table.Column<int>(type: "int", nullable: false),
                    CRM = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicos_EspecialidadesMedicas_EspecialidadeId",
                        column: x => x.EspecialidadeId,
                        principalTable: "EspecialidadesMedicas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Medicos_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PessoaId = table.Column<int>(type: "int", nullable: false),
                    ConvenioId = table.Column<int>(type: "int", nullable: false),
                    Situacao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacientes_Convenios_ConvenioId",
                        column: x => x.ConvenioId,
                        principalTable: "Convenios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pacientes_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Recepcionistas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PessoaId = table.Column<int>(type: "int", nullable: false),
                    Bloco = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recepcionistas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recepcionistas_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Prontuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    MedicoId = table.Column<int>(type: "int", nullable: false),
                    QueixaPrincipal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HistoricoFamiliar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExameFisico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Condutas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HipoteseDiagnostica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prescricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prontuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prontuarios_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Convenios",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Clinipam" },
                    { 2, "Unimed" },
                    { 3, "SC Saúde" },
                    { 4, "Amil" },
                    { 5, "Boa Saúde" },
                    { 6, "Bradesco Saúde" },
                    { 7, "HapVida" }
                });

            migrationBuilder.InsertData(
                table: "EspecialidadesMedicas",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Especialista em Cardiologia" },
                    { 2, "Especialista em Dermatologia" },
                    { 3, "Especialista em Endoscopia" },
                    { 4, "Especialista em Ginecologia e Obstetrícia" },
                    { 5, "Especialista em Nutrologia" },
                    { 6, "Especialista em Oftalmologia" },
                    { 7, "Especialista em Oncologia Clínica" },
                    { 8, "Especialista em Ortopedia e Traumatologia" },
                    { 9, "Especialista em Otorrinolaringologia" },
                    { 10, "Especialista em Pediatria" },
                    { 11, "Especialista em Pneumologia" },
                    { 12, "Especialista em Psiquiatria" },
                    { 13, "Especialista em Radioterapia" },
                    { 14, "Especialista em Reumatologia" },
                    { 15, "Especialista em Urologia" }
                });

            migrationBuilder.InsertData(
                table: "Pessoas",
                columns: new[] { "Id", "Cpf", "CreatedOn", "DataNascimento", "Email", "Naturalidade", "Nome", "Perfil", "Rg", "Senha", "Sexo", "Sobrenome", "Telefone" },
                values: new object[,]
                {
                    { 1, "156.789.754-85", new DateTime(2023, 2, 7, 18, 37, 20, 919, DateTimeKind.Local).AddTicks(4656), new DateTime(2023, 2, 7, 18, 37, 20, 919, DateTimeKind.Local).AddTicks(4641), "ana@gmail.com", "Blumenau/SC", "Ana", 2, "7.654.852", "123", 0, "da Silva", "(47)3339-4832" },
                    { 2, "456.799.466-65", new DateTime(2023, 2, 7, 18, 37, 20, 919, DateTimeKind.Local).AddTicks(4659), new DateTime(2023, 2, 7, 18, 37, 20, 919, DateTimeKind.Local).AddTicks(4659), "carlos@gmail.com", "Criciúma/SC", "Carlos", 1, "7.654.852", "123", 1, "da Silva", "(47)3339-1235" },
                    { 3, "787.464.796-56", new DateTime(2023, 2, 7, 18, 37, 20, 919, DateTimeKind.Local).AddTicks(4660), new DateTime(2023, 2, 7, 18, 37, 20, 919, DateTimeKind.Local).AddTicks(4660), "maria@gmail.com", "Joinville/SC", "Maria Clara", 3, "7.654.852", "123", 0, "da Silva", "(47)3339-8923" },
                    { 4, "899.799.465-78", new DateTime(2023, 2, 7, 18, 37, 20, 919, DateTimeKind.Local).AddTicks(4662), new DateTime(2023, 2, 7, 18, 37, 20, 919, DateTimeKind.Local).AddTicks(4661), "joao@gmail.com", "Blumenau/SC", "Jupiter", 0, "7.654.852", "123", 2, "da Silva", "(47)3339-8965" }
                });

            migrationBuilder.InsertData(
                table: "Enderecos",
                columns: new[] { "Id", "Bairro", "Cep", "Cidade", "Numero", "PessoaId", "Rua", "UF" },
                values: new object[,]
                {
                    { 1, "Nossa Senhora Aparecida", "01001-000", "São Paulo", "18", 1, "Rua Fulaninho de Assis", "SP" },
                    { 2, "Fortaleza", "89055-440", "Santa Catarina", "5", 2, "Rua Fulaninho Monteiro", "SC" },
                    { 3, "Nossa Senhora Aparecida", "01001-000", "São Paulo", "18", 3, "Rua Fulaninho de Assis", "SP" },
                    { 4, "Itoupava", "89741-123", "Belo Horizonte", "4562", 4, "Rua Fulaninho de Souza", "Minas Gerais" }
                });

            migrationBuilder.InsertData(
                table: "Medicos",
                columns: new[] { "Id", "CRM", "EspecialidadeId", "PessoaId" },
                values: new object[] { 1, "6546hk55w", 10, 2 });

            migrationBuilder.InsertData(
                table: "Pacientes",
                columns: new[] { "Id", "ConvenioId", "PessoaId", "Situacao" },
                values: new object[] { 1, 1, 1, 2 });

            migrationBuilder.InsertData(
                table: "Recepcionistas",
                columns: new[] { "Id", "Bloco", "PessoaId" },
                values: new object[] { 1, "02-D", 3 });

            migrationBuilder.InsertData(
                table: "Prontuarios",
                columns: new[] { "Id", "Condutas", "CreatedOn", "Descricao", "ExameFisico", "HipoteseDiagnostica", "HistoricoFamiliar", "MedicoId", "PacienteId", "Prescricao", "QueixaPrincipal" },
                values: new object[,]
                {
                    { 1, "Solicito EDA, PHmetria e exames laboratoriais ", new DateTime(2023, 2, 7, 18, 37, 20, 919, DateTimeKind.Local).AddTicks(4769), "Aproximadamente há 20 dias, evoluiu uma dor forte na barriga que piora com café e bebidas ácidas", "BNF sem SA, MVUA sem alterações, dor a palpação de região epigástrica", "K29 - Gastrite e duodenite", "Ninguém na família com sistomas parecidos", 1, 1, "Annita de 12/12hs por 3 dias", "Dor na barriga" },
                    { 2, "Solicito EDA, PHmetria e exames laboratoriais ", new DateTime(2023, 2, 7, 18, 37, 20, 919, DateTimeKind.Local).AddTicks(4775), "Aproximadamente há 20 dias, evoluiu uma dor forte na cabeça", "BNF sem SA, MVUA sem alterações, dor a palpação de região epigástrica", "Dor de cabeça normal", "Ninguém na família com sistomas parecidos", 1, 1, "Dipirona de 12/12hs por 3 dias", "Dor de cabeça" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_PessoaId",
                table: "Enderecos",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_EspecialidadeId",
                table: "Medicos",
                column: "EspecialidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_PessoaId",
                table: "Medicos",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_ConvenioId",
                table: "Pacientes",
                column: "ConvenioId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_PessoaId",
                table: "Pacientes",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Prontuarios_MedicoId",
                table: "Prontuarios",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Recepcionistas_PessoaId",
                table: "Recepcionistas",
                column: "PessoaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Prontuarios");

            migrationBuilder.DropTable(
                name: "Recepcionistas");

            migrationBuilder.DropTable(
                name: "Convenios");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "EspecialidadesMedicas");

            migrationBuilder.DropTable(
                name: "Pessoas");
        }
    }
}
