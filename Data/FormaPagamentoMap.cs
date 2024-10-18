using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class FormaPagamentoMap : IEntityTypeConfiguration<FormaPagamentoModel>
    {
        public void Configure(EntityTypeBuilder<FormaPagamentoModel> builder)
        {
            builder.HasKey(x => x.FormaPagamentoId);
            builder.Property(x => x.NomeFormaPagamento).IsRequired().HasMaxLength(255);         
        }
    }
}
