using Financeiro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financeiro.Infrastructure.Data.Mappings;

public class IncomeMapping : IEntityTypeConfiguration<Income>
{
    public void Configure(EntityTypeBuilder<Income> builder)
    {
        builder.ToTable("Incomes");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               .ValueGeneratedNever();

        builder.Property(x => x.UserId)
               .IsRequired();

        builder.Property(x => x.Amount)
               .HasPrecision(18, 2)
               .IsRequired();

        builder.Property(x => x.Description)
               .HasMaxLength(200)
               .IsRequired(false);

        builder.Property(x => x.Date)
               .IsRequired();
    }
}
