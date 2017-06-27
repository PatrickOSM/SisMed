using SisMed.Domain.Entities;
using SisMed.Infra.Data.EntityConfig;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace SisMed.Infra.Data.Context
{
    public class SisMedContext : DbContext
    {
        public SisMedContext()
            : base("SisMed")
        {

        }

        public DbSet<Cargo> Cargos { get; set; }

        public DbSet<Cidade> Cidades { get; set; }

        public DbSet<Estado> Estados { get; set; }

        public DbSet<Funcionario> Funcionarios { get; set; }

        public DbSet<Paciente> Pacientes { get; set; }

        public DbSet<Sexo> Sexos { get; set; }

        public DbSet<TipoSanguineo> TiposSanguineos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<FichaMedica> FichasMedicas { get; set; }

        public DbSet<Agenda> Agendas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Remove algumas convenções do Entity Framework
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Sempre que estiver o nome da classe com "Id" na frente, será a primary key
            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            //Define toda string como varchar na BD ao utilizar o migration
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            //Define string como "lenght 100" por padrão
            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            //Adicionar a configuração
            modelBuilder.Configurations.Add(new CargoConfiguration());
            modelBuilder.Configurations.Add(new CidadeConfiguration());
            modelBuilder.Configurations.Add(new EstadoConfiguration());
            modelBuilder.Configurations.Add(new FuncionarioConfiguration());
            modelBuilder.Configurations.Add(new PacienteConfiguration());
            modelBuilder.Configurations.Add(new SexoConfiguration());
            modelBuilder.Configurations.Add(new TipoSanguineoConfiguration());
            modelBuilder.Configurations.Add(new UsuarioConfiguration());
            modelBuilder.Configurations.Add(new AgendaConfiguration());
            modelBuilder.Configurations.Add(new FichaMedicaConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            //Define os valores de todos os "DataCadastro" das classes
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                //Usa a data atual ao ser adicionado
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                //Não realiza alterações ao ser editado
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }
            return base.SaveChanges();
        }
    }
}
