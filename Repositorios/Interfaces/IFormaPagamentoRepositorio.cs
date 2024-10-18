using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IFormaPagamentoRepositorio
    {
        Task<List<FormaPagamentoModel>> GetAll();

        Task<FormaPagamentoModel> GetById(int id);

        Task<FormaPagamentoModel> InsertFormaPagamento(FormaPagamentoModel formapagamento);

        Task<FormaPagamentoModel> UpdateFormaPagamento(FormaPagamentoModel formapagamento, int id);

        Task<bool> DeleteFormaPagamento(int id);
    }
}
