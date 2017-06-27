using SisMed.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SisMed.Infra.Data.EntityConfig
{
    public class CargoConfiguration : EntityTypeConfiguration<Cargo>
    {
        public CargoConfiguration()
        {
            HasKey(c => c.CargoId);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
