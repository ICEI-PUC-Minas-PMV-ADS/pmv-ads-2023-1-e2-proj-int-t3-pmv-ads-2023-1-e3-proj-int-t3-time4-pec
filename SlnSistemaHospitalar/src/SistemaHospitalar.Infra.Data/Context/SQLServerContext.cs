using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using SistemaHospitalar.Domain.Entities;
using SistemaHospitalar.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHospitalar.Infra.Data.Context
{
    public class SQLServerContext : DbContext
    {
        public SQLServerContext(DbContextOptions<SQLServerContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().Where(e => !e.IsOwned()).SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }

            modelBuilder.Entity<Convenio>()
                .HasData(
                new {Id = 1, Nome = "Clinipam"},
                new { Id = 2, Nome = "Unimed" },
                new { Id = 3, Nome = "SC Saúde" },
                new { Id = 4, Nome = "Amil" },
                new { Id = 5, Nome = "Boa Saúde" },
                new { Id = 6, Nome = "Bradesco Saúde" },
                new { Id = 7, Nome = "HapVida" }
                );

            modelBuilder.Entity<EspecialidadeMedica>()
                .HasData(
                new {Id = 1, Nome = "Especialista em Cardiologia" },
                new { Id = 2, Nome = "Especialista em Dermatologia" },
                new { Id = 3, Nome = "Especialista em Endoscopia" },
                new { Id = 4, Nome = "Especialista em Ginecologia e Obstetrícia" },
                new { Id = 5, Nome = "Especialista em Nutrologia" },
                new { Id = 6, Nome = "Especialista em Oftalmologia" },
                new { Id = 7, Nome = "Especialista em Oncologia Clínica" },
                new { Id = 8, Nome = "Especialista em Ortopedia e Traumatologia" },
                new { Id = 9, Nome = "Especialista em Otorrinolaringologia" },
                new { Id = 10, Nome = "Especialista em Pediatria" },
                new { Id = 11, Nome = "Especialista em Pneumologia" },
                new { Id = 12, Nome = "Especialista em Psiquiatria" }, 
                new { Id = 13, Nome = "Especialista em Radioterapia" },
                new { Id = 14, Nome = "Especialista em Reumatologia" },
                new { Id = 15, Nome = "Especialista em Urologia" }
                );

            modelBuilder.Entity<Pessoa>()
                .HasData(
                new {Id = 1, Nome = "Ana", Sobrenome = "da Silva", Cpf = "156.789.754-85", Rg = "7.654.852", Telefone = "(47)3339-4832", Email = "ana@gmail.com", Senha = "123", DataNascimento = DateTime.Now, Naturalidade = "Blumenau/SC", Sexo = SexoEnum.Feminino, Perfil = PerfilEnum.Paciente, CreatedOn = DateTime.Now },
                new { Id = 2, Nome = "Carlos", Sobrenome = "da Silva", Cpf = "456.799.466-65", Rg = "7.654.852", Telefone = "(47)3339-1235", Email = "carlos@gmail.com", Senha = "123", DataNascimento = DateTime.Now, Naturalidade = "Criciúma/SC", Sexo = SexoEnum.Masculino, Perfil = PerfilEnum.Medico, CreatedOn = DateTime.Now },
                new { Id = 3, Nome = "Maria Clara", Sobrenome = "da Silva", Cpf = "787.464.796-56", Rg = "7.654.852", Telefone = "(47)3339-8923", Email = "maria@gmail.com", Senha = "123", DataNascimento = DateTime.Now, Naturalidade = "Joinville/SC", Sexo = SexoEnum.Feminino, Perfil = PerfilEnum.Recepcionista, CreatedOn = DateTime.Now },
                new { Id = 4, Nome = "Jupiter", Sobrenome = "da Silva", Cpf = "899.799.465-78", Rg = "7.654.852", Telefone = "(47)3339-8965", Email = "joao@gmail.com", Senha = "123", DataNascimento = DateTime.Now, Naturalidade = "Blumenau/SC", Sexo = SexoEnum.NãoBinario, Perfil = PerfilEnum.Admin, CreatedOn = DateTime.Now }

                );

            modelBuilder.Entity<Endereco>()
                .HasData(
                new {Id = 1, PessoaId = 1, Cep = "01001-000", Rua = "Rua Fulaninho de Assis", Numero = "18", Bairro = "Nossa Senhora Aparecida", Cidade = "São Paulo", UF = "SP" },
                new { Id = 2, PessoaId = 2, Cep = "89055-440", Rua = "Rua Fulaninho Monteiro", Numero = "5", Bairro = "Fortaleza", Cidade = "Santa Catarina", UF = "SC" },
                new { Id = 3, PessoaId = 3, Cep = "01001-000", Rua = "Rua Fulaninho de Assis", Numero = "18", Bairro = "Nossa Senhora Aparecida", Cidade = "São Paulo", UF = "SP" },
                new { Id = 4, PessoaId = 4, Cep = "89741-123", Rua = "Rua Fulaninho de Souza", Numero = "4562", Bairro = "Itoupava", Cidade = "Belo Horizonte", UF = "Minas Gerais" }
                );

            modelBuilder.Entity<Paciente>()
                .HasData(
                new {Id = 1, PessoaId = 1, ConvenioId = 1, Situacao = SituacaoEnum.Ativo}
                );

            modelBuilder.Entity<Medico>()
                .HasData(
                new {Id = 1, PessoaId = 2, EspecialidadeId = 10, CRM = "6546hk55w"}
                );

            modelBuilder.Entity<Recepcionista>()
                .HasData(
                new {Id = 1, PessoaId = 3, Bloco = "02-D"}
                );

            modelBuilder.Entity<Prontuario>()
                .HasData(
                new {Id = 1, PacienteId = 1, MedicoId = 1, QueixaPrincipal = "Dor na barriga", Descricao = "Aproximadamente há 20 dias, evoluiu uma dor forte na barriga que piora com café e bebidas ácidas", HistoricoFamiliar = "Ninguém na família com sistomas parecidos", ExameFisico = "BNF sem SA, MVUA sem alterações, dor a palpação de região epigástrica", Condutas = "Solicito EDA, PHmetria e exames laboratoriais ", HipoteseDiagnostica = "K29 - Gastrite e duodenite", Prescricao = "Annita de 12/12hs por 3 dias", CreatedOn = DateTime.Now},
                new { Id = 2, PacienteId = 1, MedicoId = 1, QueixaPrincipal = "Dor de cabeça", Descricao = "Aproximadamente há 20 dias, evoluiu uma dor forte na cabeça", HistoricoFamiliar = "Ninguém na família com sistomas parecidos", ExameFisico = "BNF sem SA, MVUA sem alterações, dor a palpação de região epigástrica", Condutas = "Solicito EDA, PHmetria e exames laboratoriais ", HipoteseDiagnostica = "Dor de cabeça normal", Prescricao = "Dipirona de 12/12hs por 3 dias", CreatedOn = DateTime.Now }
                );
        }


        #region DbSets

        public DbSet<Convenio> Convenios { get; set; }
        public DbSet<EspecialidadeMedica> EspecialidadesMedicas { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Recepcionista> Recepcionistas { get; set; }
        public DbSet<Prontuario> Prontuarios { get; set; }

        #endregion
    }
}
