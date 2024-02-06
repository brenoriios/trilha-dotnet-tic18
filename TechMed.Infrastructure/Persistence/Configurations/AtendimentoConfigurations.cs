using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechMed.Domain.Entities;

namespace TechMed.Infrastructure.Persistence.Configurations;
public class AtendimentoConfigurations : IEntityTypeConfiguration<Atendimento>
{
    public void Configure(EntityTypeBuilder<Atendimento> builder)
    {
        builder.HasKey(a => a.AtendimentoId);
    }
}
