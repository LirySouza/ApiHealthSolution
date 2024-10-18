using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IPagamentoRepositorio
    {
        Task<List<PagamentoModel>> GetAll();

        Task<PagamentoModel> GetById(int id);

        Task<PagamentoModel> InsertPagamento(PagamentoModel pagamento);

        Task<PagamentoModel> UpdatePagamento(PagamentoModel pagamento, int id);

        Task<bool> DeletePagamento(int id);
    }
}
