using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Api.Repositorios
{
    public class PagamentoRepositorio : IPagamentoRepositorio
    {
        private readonly Contexto _dbContext;

        public PagamentoRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<PagamentoModel>> GetAll()
        {
            return await _dbContext.Pagamento.ToListAsync();
        }

        public async Task<PagamentoModel> GetById(int id)
        {
            return await _dbContext.Pagamento.FirstOrDefaultAsync(x => x.PagamentoId == id);
        }

        public async Task<PagamentoModel> InsertPagamento(PagamentoModel Pagamento)
        {
            await _dbContext.Pagamento.AddAsync(Pagamento);
            await _dbContext.SaveChangesAsync();
            return Pagamento;
        }

        public async Task<PagamentoModel> UpdatePagamento(PagamentoModel requisicao, int id)
        {
            PagamentoModel pagamento = await GetById(id);
            if (pagamento == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                pagamento.TipoConsultaId = requisicao.TipoConsultaId;
                pagamento.FormaPagamentoId = requisicao.FormaPagamentoId;
                pagamento.ValorPagamento = requisicao.ValorPagamento;
                pagamento.DataPagamento = requisicao.DataPagamento;
                pagamento.ObsPagamento = requisicao.ObsPagamento;
                _dbContext.Pagamento.Update(pagamento);
                await _dbContext.SaveChangesAsync();
            }
            return pagamento;

        }

        public async Task<bool> DeletePagamento(int id)
        {
            PagamentoModel Pagamento = await GetById(id);
            if (Pagamento == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Pagamento.Remove(Pagamento);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}

