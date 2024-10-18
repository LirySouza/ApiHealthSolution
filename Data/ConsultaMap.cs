using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class ConsultaMap : IEntityTypeConfiguration<ConsultaModel>
    {
        public void Configure(EntityTypeBuilder<ConsultaModel> builder)
        {
            builder.HasKey(x => x.ConsultaId);
            builder.Property(x => x.NomeConsulta).IsRequired().HasMaxLength(255);
            builder.Property(x => x.PacienteId).IsRequired();
            builder.Property(x => x.ObsConsulta).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ProfissionalId).IsRequired();
            builder.Property(x => x.DataConsulta).IsRequired();
        }
    }
}
