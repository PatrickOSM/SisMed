using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using SisMed.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SisMed.Infra.Data.EntityConfig
{
    public class FuncionarioConfiguration : EntityTypeConfiguration<Funcionario>
    {
        public FuncionarioConfiguration()
        {
            HasKey(c => c.FuncionarioId);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(50);

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

            Property(c => c.CargoId)
                .IsRequired();

            HasRequired(c => c.Cargo)
                .WithMany()
                .HasForeignKey(c => c.CargoId);

            Property(c => c.DataNascimento)
                .IsRequired();

            Property(c => c.SexoId)
                .IsRequired();

            HasRequired(c => c.Sexo)
                .WithMany()
                .HasForeignKey(c => c.SexoId);

            Property(c => c.Matricula)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute()))
                .HasMaxLength(10);

            Property(c => c.Telefone)
                .IsRequired()
                .HasMaxLength(15);

            Property(c => c.Email)
                .HasMaxLength(100);

            HasMany(s => s.Agendas)
                    .WithRequired(s => s.Funcionario)
                    .HasForeignKey(s => s.FuncionarioId);

            HasOptional(u => u.Usuario)
                .WithRequired(u => u.Funcionario);
        }
    }
}
