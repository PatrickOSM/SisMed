using System;
using Microsoft.AspNet.Identity;
using SisMed.Domain.Entities;
using SisMed.Infra.Data.Context;

namespace SisMed.Infra.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<SisMedContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SisMedContext context)
        {
            context.Estados.AddOrUpdate(x => x.EstadoId,
                new Estado { EstadoId = 0, Nome = "Acre", Sigla = "AC" },
                new Estado { EstadoId = 1, Nome = "Alagoas", Sigla = "AL" },
                new Estado { EstadoId = 2, Nome = "Amapá", Sigla = "AP" },
                new Estado { EstadoId = 3, Nome = "Amazonas", Sigla = "AM" },
                new Estado { EstadoId = 4, Nome = "Bahia", Sigla = "BA" },
                new Estado { EstadoId = 5, Nome = "Ceará", Sigla = "CE" },
                new Estado { EstadoId = 6, Nome = "Distrito Federal", Sigla = "DF" },
                new Estado { EstadoId = 7, Nome = "Espírito Santo", Sigla = "ES" },
                new Estado { EstadoId = 8, Nome = "Goiás", Sigla = "GO" },
                new Estado { EstadoId = 9, Nome = "Maranhão", Sigla = "MA" },
                new Estado { EstadoId = 10, Nome = "Mato Grosso", Sigla = "MT" },
                new Estado { EstadoId = 11, Nome = "Mato Grosso do Sul", Sigla = "MS" },
                new Estado { EstadoId = 12, Nome = "Minas Gerais", Sigla = "MG" },
                new Estado { EstadoId = 13, Nome = "Pará", Sigla = "PA" },
                new Estado { EstadoId = 14, Nome = "Paraíba", Sigla = "PB" },
                new Estado { EstadoId = 15, Nome = "Paraná", Sigla = "PR" },
                new Estado { EstadoId = 16, Nome = "Pernambuco", Sigla = "PE" },
                new Estado { EstadoId = 17, Nome = "Piauí", Sigla = "PI" },
                new Estado { EstadoId = 18, Nome = "Rio de Janeiro", Sigla = "RJ" },
                new Estado { EstadoId = 19, Nome = "Rio Grande do Norte", Sigla = "RN" },
                new Estado { EstadoId = 20, Nome = "Rio Grande do Sul", Sigla = "RS" },
                new Estado { EstadoId = 21, Nome = "Rondônia", Sigla = "RO" },
                new Estado { EstadoId = 22, Nome = "Roraima", Sigla = "RR" },
                new Estado { EstadoId = 23, Nome = "Santa Catarina", Sigla = "SC" },
                new Estado { EstadoId = 24, Nome = "São Paulo", Sigla = "SP" },
                new Estado { EstadoId = 25, Nome = "Sergipe", Sigla = "SE" },
                new Estado { EstadoId = 26, Nome = "Tocantins", Sigla = "TO" }
                );

            context.Cidades.AddOrUpdate(x => x.CidadeId,
                new Cidade { CidadeId = 0, EstadoId = 12, Nome = "Ipatinga" },
                new Cidade { CidadeId = 1, EstadoId = 12, Nome = "Dom Cavati" },
                new Cidade { CidadeId = 2, EstadoId = 12, Nome = "Iapu" },
                new Cidade { CidadeId = 3, EstadoId = 12, Nome = "Inhapim" },
                new Cidade { CidadeId = 4, EstadoId = 12, Nome = "Santana do Paraíso" },
                new Cidade { CidadeId = 5, EstadoId = 12, Nome = "Timóteo" },
                new Cidade { CidadeId = 6, EstadoId = 12, Nome = "Coronel Fabriciano" },
                new Cidade { CidadeId = 7, EstadoId = 12, Nome = "Caratinga" },
                new Cidade { CidadeId = 8, EstadoId = 12, Nome = "Ipaba" },
                new Cidade { CidadeId = 9, EstadoId = 12, Nome = "Pingo d'agua" }
                );

            context.TiposSanguineos.AddOrUpdate(x => x.TipoSanguineoId,
                new TipoSanguineo { TipoSanguineoId = 0, Nome = "A+" },
                new TipoSanguineo { TipoSanguineoId = 1, Nome = "A-" },
                new TipoSanguineo { TipoSanguineoId = 2, Nome = "B+" },
                new TipoSanguineo { TipoSanguineoId = 3, Nome = "B-" },
                new TipoSanguineo { TipoSanguineoId = 4, Nome = "AB+" },
                new TipoSanguineo { TipoSanguineoId = 5, Nome = "AB-" },
                new TipoSanguineo { TipoSanguineoId = 6, Nome = "O+" },
                new TipoSanguineo { TipoSanguineoId = 7, Nome = "O-" }
                );

            context.Cargos.AddOrUpdate(x => x.CargoId,
                new Cargo { CargoId = 0, Nome = "Administrador", Descricao = "Possui controle total do sistema." },
                new Cargo { CargoId = 1, Nome = "Médico(a)", Descricao = "Responsável pelo atendimento dos pacientes." },
                new Cargo { CargoId = 2, Nome = "Secretária", Descricao = "Atendimento ao público, cadastro e acompanhamento no pré atendimento." }
                );

            context.Sexos.AddOrUpdate(x => x.SexoId,
               new Sexo { SexoId = 0, Nome = "Masculino" },
               new Sexo { SexoId = 1, Nome = "Feminino" },
               new Sexo { SexoId = 3, Nome = "Transgênero" }
               );

            //Adicionar usuário padrão
            var passwordHash = new PasswordHasher();
            var senha = passwordHash.HashPassword("1551 @Senha");

            context.Funcionarios.AddOrUpdate(f => f.FuncionarioId,
                new Funcionario
                {
                    FuncionarioId = 0,
                    Ativo = true,
                    Bairro = "Centro",
                    CargoId = 0,
                    Cep = "35168-953",
                    CidadeId = 0,
                    Email = "admin@sismed.com",
                    DataCadastro = DateTime.Now,
                    Matricula = "140355586",
                    Nome = "Patrick Moreno",
                    SexoId = 0,
                    Telefone = "(33)5169-0582",
                    Rg = "19180255",
                    Rua = "Macedônia",
                    Cpf = "128.658.962-20",
                    DataNascimento = DateTime.Now
                });

            context.Usuarios.AddOrUpdate(u => u.UserName,
                new Usuario()
                {
                    UserName = "admin@sismed.com",
                    Email = "admin@sismed.com",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PasswordHash = senha,
                    Funcionario = new Funcionario
                    {
                        FuncionarioId = 0,
                        Ativo = true,
                        Bairro = "Centro",
                        CargoId = 0,
                        Cep = "35168-953",
                        CidadeId = 0,
                        Email = "admin@sismed.com",
                        DataCadastro = DateTime.Now,
                        Matricula = "140355586",
                        Nome = "Patrick Moreno",
                        SexoId = 0,
                        Telefone = "(33)5169-0582",
                        Rg = "19180255",
                        Rua = "Macedônia",
                        Cpf = "128.658.962-20",
                        DataNascimento = DateTime.Now
                    }
                });
        }
    }
}
