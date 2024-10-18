using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class PagamentolMap : IEntityTypeConfiguration<PagamentoModel>
    {
        public void Configure(EntityTypeBuilder<PagamentoModel> builder)
        {
            builder.HasKey(x => x.PagamentoId);
            builder.Property(x => x.ConsultaId).IsRequired();
            builder.Property(x => x.FormaPagamentoId).IsRequired();
            builder.Property(x => x.ValorPagamento).IsRequired().HasMaxLength(255);
            builder.Property(x => x.DataPagamento).IsRequired();
            builder.Property(x => x.ObsPagamento).IsRequired().HasMaxLength(255);
        }
    }
}
