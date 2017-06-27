using SisMed.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SisMed.Infra.Data.EntityConfig
{
    public class CidadeConfiguration : EntityTypeConfiguration<Cidade>
    {
        public CidadeConfiguration()
        {
            HasKey(c => c.CidadeId);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(50);

            Property(c => c.CidadeId)
                .IsRequired();

            HasRequired(c => c.Estado)
                .WithMany()
                .HasForeignKey(c => c.EstadoId);
        }
    }
}
