using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class TipoSexoMap : IEntityTypeConfiguration<TipoSexoModel>
    {
        public void Configure(EntityTypeBuilder<TipoSexoModel> builder)
        {
            builder.HasKey(x => x.TipoSexoId);
            builder.Property(x => x.NomeTipoSexo).IsRequired().HasMaxLength(255);
        }
    }
}

