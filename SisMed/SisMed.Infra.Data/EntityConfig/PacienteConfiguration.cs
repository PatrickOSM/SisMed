using SisMed.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SisMed.Infra.Data.EntityConfig
{
    public class PacienteConfiguration : EntityTypeConfiguration<Paciente>
    {
        public PacienteConfiguration()
        {
            HasKey(c => c.PacienteId);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(50);

            Property(c => c.SexoId)
                .IsRequired();

            HasRequired(c => c.Sexo)
                .WithMany()
                .HasForeignKey(c => c.SexoId);

            Property(c => c.Rua)
                .IsRequired()
                .HasMaxLength(50);

            Property(c => c.Cpf)
                .IsRequired()
                .HasMaxLength(15);

            Property(c => c.Rg)
                .IsRequired()
                .HasMaxLength(15);

            Property(c => c.Cep)
                .IsRequired()
                .HasMaxLength(10);

            Property(c => c.CidadeId)
                .IsRequired();

            HasRequired(c => c.Cidade)
                .WithMany()
                .HasForeignKey(c => c.CidadeId);

            Property(c => c.Bairro)
                .IsRequired()
                .HasMaxLength(50);

            Property(c => c.DataNascimento)
                .IsRequired();

            Property(c => c.Telefone)
                .IsRequired()
                .HasMaxLength(15);

            Property(c => c.TelefoneEmergencia)
                .HasMaxLength(15);

            Property(c => c.NomeMae)
                .IsRequired()
                .HasMaxLength(50);

            Property(c => c.NomePai)
                .HasMaxLength(50);

            HasRequired(c => c.TipoSanguineo)
                .WithMany()
                .HasForeignKey(c => c.TipoSanguineoId);

            HasMany(s => s.Agendas)
                    .WithRequired(s => s.Paciente)
                    .HasForeignKey(s => s.PacienteId);
        }
    }
}
