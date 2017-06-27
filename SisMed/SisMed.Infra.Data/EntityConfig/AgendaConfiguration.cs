using SisMed.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SisMed.Infra.Data.EntityConfig
{
    public class AgendaConfiguration : EntityTypeConfiguration<Agenda>
    {
        public AgendaConfiguration()
        {
            HasKey(c => c.AgendaId);

            Property(c => c.Titulo)
                .IsRequired()
                .HasMaxLength(50);

            Property(c => c.DataInicio)
                .IsRequired();

            Property(c => c.Duracao)
                .IsRequired();

            Property(c => c.Status)
                .IsRequired();

            HasRequired(c => c.Funcionario)
                    .WithMany(c => c.Agendas)
                    .HasForeignKey(s => s.FuncionarioId);

            HasRequired(c => c.Paciente)
                    .WithMany(c => c.Agendas)
                    .HasForeignKey(s => s.PacienteId);
        }
    }
}
