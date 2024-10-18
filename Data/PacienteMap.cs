using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class PacienteMap : IEntityTypeConfiguration<PacienteModel>
    {
        public void Configure(EntityTypeBuilder<PacienteModel> builder)
        {
            builder.HasKey(x => x.PacienteId);
            builder.Property(x => x.NomePaciente).IsRequired().HasMaxLength(255);
            builder.Property(x => x.DataNascimento).IsRequired().HasMaxLength(255);
            builder.Property(x => x.TipoSexoId).IsRequired();
            builder.Property(x => x.CpfPaciente).IsRequired();
            builder.Property(x => x.EnderecoPaciente).IsRequired().HasMaxLength(300);
            builder.Property(x => x.TelefonePaciente).IsRequired();
        }
    }
}

