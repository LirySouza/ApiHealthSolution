namespace Api.Models
{
    public class PagamentoModel
    {
        public int PagamentoId { get; set; }

        public int ConsultaId { get; set; }

        public int FormaPagamentoId { get; set; }

        public string ValorPagamento { get; set; } = string.Empty;

        public DateTime DataPagamento { get; set; }

        public string ObsPagamento { get; set; } = string.Empty;
    }
}
