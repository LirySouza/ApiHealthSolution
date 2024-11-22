using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class TipoConsultaMap : IEntityTypeConfiguration<TipoConsultaModel>
    {
        public void Configure(EntityTypeBuilder<TipoConsultaModel> builder)
        {
            builder.HasKey(x => x.TipoConsultaId);
            builder.Property(x => x.NomeTipoConsulta).IsRequired().HasMaxLength(255);
         
        }
    }
}
