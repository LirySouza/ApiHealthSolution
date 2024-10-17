using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class TipoProfissionalMap : IEntityTypeConfiguration<TipoProfissionalModel>
    {
        public void Configure(EntityTypeBuilder<TipoProfissionalModel> builder)
        {
            builder.HasKey(x => x.TipoProfissionalId);
            builder.Property(x => x.NomeTipoProfissional).IsRequired().HasMaxLength(255);         
        }
    }
}
