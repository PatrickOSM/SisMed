namespace SisMed.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SisMed : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agenda",
                c => new
                    {
                        AgendaId = c.Int(nullable: false, identity: true),
                        Titulo = c.String(nullable: false, maxLength: 50, unicode: false),
                        DataInicio = c.DateTime(nullable: false),
                        Duracao = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        FuncionarioId = c.Int(nullable: false),
                        PacienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AgendaId)
                .ForeignKey("dbo.Funcionario", t => t.FuncionarioId)
                .ForeignKey("dbo.Paciente", t => t.PacienteId)
                .Index(t => t.FuncionarioId)
                .Index(t => t.PacienteId);
            
            CreateTable(
                "dbo.Funcionario",
                c => new
                    {
                        FuncionarioId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50, unicode: false),
                        SexoId = c.Int(nullable: false),
                        CargoId = c.Int(nullable: false),
                        Matricula = c.String(nullable: false, maxLength: 10, unicode: false),
                        Ativo = c.Boolean(nullable: false),
                        Email = c.String(maxLength: 100, unicode: false),
                        Cpf = c.String(nullable: false, maxLength: 15, unicode: false),
                        Rg = c.String(nullable: false, maxLength: 15, unicode: false),
                        DataNascimento = c.DateTime(nullable: false),
                        Rua = c.String(nullable: false, maxLength: 50, unicode: false),
                        Cep = c.String(nullable: false, maxLength: 10, unicode: false),
                        Bairro = c.String(nullable: false, maxLength: 50, unicode: false),
                        CidadeId = c.Int(nullable: false),
                        Telefone = c.String(nullable: false, maxLength: 15, unicode: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FuncionarioId)
                .ForeignKey("dbo.Cargo", t => t.CargoId)
                .ForeignKey("dbo.Cidade", t => t.CidadeId)
                .ForeignKey("dbo.Sexo", t => t.SexoId)
                .Index(t => t.SexoId)
                .Index(t => t.CargoId)
                .Index(t => t.Matricula)
                .Index(t => t.CidadeId);
            
            CreateTable(
                "dbo.Cargo",
                c => new
                    {
                        CargoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50, unicode: false),
                        Descricao = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.CargoId);
            
            CreateTable(
                "dbo.Cidade",
                c => new
                    {
                        CidadeId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50, unicode: false),
                        EstadoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CidadeId)
                .ForeignKey("dbo.Estado", t => t.EstadoId)
                .Index(t => t.EstadoId);
            
            CreateTable(
                "dbo.Estado",
                c => new
                    {
                        EstadoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50, unicode: false),
                        Sigla = c.String(nullable: false, maxLength: 2, unicode: false),
                    })
                .PrimaryKey(t => t.EstadoId);
            
            CreateTable(
                "dbo.FichaMedica",
                c => new
                    {
                        FichaMedicaId = c.Int(nullable: false, identity: true),
                        DataConsulta = c.DateTime(nullable: false),
                        ExamesSolicitados = c.String(maxLength: 2000, unicode: false),
                        SintomasPaciente = c.String(maxLength: 2000, unicode: false),
                        MedicamentosReceitados = c.String(maxLength: 2000, unicode: false),
                        AnotacoesMedicas = c.String(maxLength: 2000, unicode: false),
                        FuncionarioId = c.Int(nullable: false),
                        PacienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FichaMedicaId)
                .ForeignKey("dbo.Funcionario", t => t.FuncionarioId)
                .ForeignKey("dbo.Paciente", t => t.PacienteId)
                .Index(t => t.FuncionarioId)
                .Index(t => t.PacienteId);
            
            CreateTable(
                "dbo.Paciente",
                c => new
                    {
                        PacienteId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50, unicode: false),
                        SexoId = c.Int(nullable: false),
                        Cpf = c.String(nullable: false, maxLength: 15, unicode: false),
                        Rg = c.String(nullable: false, maxLength: 15, unicode: false),
                        DataNascimento = c.DateTime(nullable: false),
                        NomeMae = c.String(nullable: false, maxLength: 50, unicode: false),
                        NomePai = c.String(maxLength: 50, unicode: false),
                        Rua = c.String(nullable: false, maxLength: 50, unicode: false),
                        Cep = c.String(nullable: false, maxLength: 10, unicode: false),
                        Bairro = c.String(nullable: false, maxLength: 50, unicode: false),
                        CidadeId = c.Int(nullable: false),
                        Telefone = c.String(nullable: false, maxLength: 15, unicode: false),
                        TelefoneEmergencia = c.String(maxLength: 15, unicode: false),
                        TipoSanguineoId = c.Int(nullable: false),
                        Alergico = c.Boolean(nullable: false),
                        Alergias = c.String(maxLength: 100, unicode: false),
                        DoencaCronica = c.Boolean(nullable: false),
                        DoencasCronicas = c.String(maxLength: 100, unicode: false),
                        MedicamentosContinuo = c.String(maxLength: 100, unicode: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PacienteId)
                .ForeignKey("dbo.Cidade", t => t.CidadeId)
                .ForeignKey("dbo.Sexo", t => t.SexoId)
                .ForeignKey("dbo.TipoSanguineo", t => t.TipoSanguineoId)
                .Index(t => t.SexoId)
                .Index(t => t.CidadeId)
                .Index(t => t.TipoSanguineoId);
            
            CreateTable(
                "dbo.Sexo",
                c => new
                    {
                        SexoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.SexoId);
            
            CreateTable(
                "dbo.TipoSanguineo",
                c => new
                    {
                        TipoSanguineoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.TipoSanguineoId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, unicode: false),
                        Email = c.String(nullable: false, maxLength: 256, unicode: false),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(maxLength: 100, unicode: false),
                        SecurityStamp = c.String(maxLength: 100, unicode: false),
                        PhoneNumber = c.String(maxLength: 100, unicode: false),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256, unicode: false),
                        Funcionario_FuncionarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Funcionario", t => t.Funcionario_FuncionarioId)
                .Index(t => t.Funcionario_FuncionarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Agenda", "PacienteId", "dbo.Paciente");
            DropForeignKey("dbo.Agenda", "FuncionarioId", "dbo.Funcionario");
            DropForeignKey("dbo.AspNetUsers", "Funcionario_FuncionarioId", "dbo.Funcionario");
            DropForeignKey("dbo.Funcionario", "SexoId", "dbo.Sexo");
            DropForeignKey("dbo.FichaMedica", "PacienteId", "dbo.Paciente");
            DropForeignKey("dbo.Paciente", "TipoSanguineoId", "dbo.TipoSanguineo");
            DropForeignKey("dbo.Paciente", "SexoId", "dbo.Sexo");
            DropForeignKey("dbo.Paciente", "CidadeId", "dbo.Cidade");
            DropForeignKey("dbo.FichaMedica", "FuncionarioId", "dbo.Funcionario");
            DropForeignKey("dbo.Funcionario", "CidadeId", "dbo.Cidade");
            DropForeignKey("dbo.Cidade", "EstadoId", "dbo.Estado");
            DropForeignKey("dbo.Funcionario", "CargoId", "dbo.Cargo");
            DropIndex("dbo.AspNetUsers", new[] { "Funcionario_FuncionarioId" });
            DropIndex("dbo.Paciente", new[] { "TipoSanguineoId" });
            DropIndex("dbo.Paciente", new[] { "CidadeId" });
            DropIndex("dbo.Paciente", new[] { "SexoId" });
            DropIndex("dbo.FichaMedica", new[] { "PacienteId" });
            DropIndex("dbo.FichaMedica", new[] { "FuncionarioId" });
            DropIndex("dbo.Cidade", new[] { "EstadoId" });
            DropIndex("dbo.Funcionario", new[] { "CidadeId" });
            DropIndex("dbo.Funcionario", new[] { "Matricula" });
            DropIndex("dbo.Funcionario", new[] { "CargoId" });
            DropIndex("dbo.Funcionario", new[] { "SexoId" });
            DropIndex("dbo.Agenda", new[] { "PacienteId" });
            DropIndex("dbo.Agenda", new[] { "FuncionarioId" });
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.TipoSanguineo");
            DropTable("dbo.Sexo");
            DropTable("dbo.Paciente");
            DropTable("dbo.FichaMedica");
            DropTable("dbo.Estado");
            DropTable("dbo.Cidade");
            DropTable("dbo.Cargo");
            DropTable("dbo.Funcionario");
            DropTable("dbo.Agenda");
        }
    }
}
