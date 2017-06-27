using SisMed.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SisMed.Infra.Data.EntityConfig
{
    public class SexoConfiguration : EntityTypeConfiguration<Sexo>
    {
        public SexoConfiguration()
        {
            HasKey(c => c.SexoId);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
