using System.Data.Entity.ModelConfiguration;
using SisMed.Domain.Entities;

namespace SisMed.Infra.Data.EntityConfig
{
    public class FichaMedicaConfiguration : EntityTypeConfiguration<FichaMedica>
    {
        public FichaMedicaConfiguration()
        {
            HasKey(c => c.FichaMedicaId);

            Property(c => c.DataConsulta)
                .IsRequired();

            Property(c => c.ExamesSolicitados)
                .HasMaxLength(2000);

            Property(c => c.SintomasPaciente)
                .HasMaxLength(2000);

            Property(c => c.MedicamentosReceitados)
                .HasMaxLength(2000);

            Property(c => c.AnotacoesMedicas)
               .HasMaxLength(2000);

            HasRequired(c => c.Funcionario)
                    .WithMany(c => c.FichasMedicas)
                    .HasForeignKey(s => s.FuncionarioId);

            HasRequired(c => c.Paciente)
                    .WithMany(c => c.FichasMedicas)
                    .HasForeignKey(s => s.PacienteId);
        }
    }
}
