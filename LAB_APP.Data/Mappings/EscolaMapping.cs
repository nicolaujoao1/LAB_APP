using LAB_APP.Domain.Consts;
using LAB_APP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace LAB_APP.Data.Mappings
{
    public class EscolaMapping : IEntityTypeConfiguration<Escola>
    {
        public void Configure(EntityTypeBuilder<Escola> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
           .IsRequired()
           .HasMaxLength(255);

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100);
                //.HasAnnotation("RegularExpression", new RegularExpressionAttribute(Mapping.EMAIL_REGEX));

            builder.Property(c => c.NumeroDeSalas)
                .IsRequired();

            builder.Property(c => c.Provincia)
                .IsRequired()
                .HasMaxLength(255);

            builder.ToTable($"{Mapping.PREFIX}{nameof(Escola)}");
        }
    }
}
