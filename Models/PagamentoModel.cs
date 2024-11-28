namespace Api.Models
{
    public class PagamentoModel
    {
        public int PagamentoId { get; set; }

        public int TipoConsultaId { get; set; }

        public int FormaPagamentoId { get; set; }

        public double ValorPagamento { get; set; }

        public DateTime DataPagamento { get; set; }

        public string ObsPagamento { get; set; } = string.Empty;
    }
}
