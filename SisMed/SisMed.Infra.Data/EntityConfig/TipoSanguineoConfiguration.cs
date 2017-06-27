using SisMed.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SisMed.Infra.Data.EntityConfig
{
    public class TipoSanguineoConfiguration : EntityTypeConfiguration<TipoSanguineo>
    {
        public TipoSanguineoConfiguration()
        {
            HasKey(c => c.TipoSanguineoId);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
