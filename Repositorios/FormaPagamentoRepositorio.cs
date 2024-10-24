using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositorios
{
    public class FormaPagamentoRepositorio : IFormaPagamentoRepositorio
    {
        private readonly Contexto _dbContext;

        public FormaPagamentoRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<FormaPagamentoModel>> GetAll()
        {
            return await _dbContext.FormaPagamento.ToListAsync();
        }

        public async Task<FormaPagamentoModel> GetById(int id)
        {
            return await _dbContext.FormaPagamento.FirstOrDefaultAsync(x => x.FormaPagamentoId == id);
        }

        public async Task<FormaPagamentoModel> InsertFormaPagamento(FormaPagamentoModel FormaPagamento)
        {
            await _dbContext.FormaPagamento.AddAsync(FormaPagamento);
            await _dbContext.SaveChangesAsync();
            return FormaPagamento;
        }

        public async Task<FormaPagamentoModel> UpdateFormaPagamento(FormaPagamentoModel requisicao, int id)
        {
            FormaPagamentoModel formapagamento = await GetById(id);
            if (formapagamento == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                formapagamento.NomeFormaPagamento = requisicao.NomeFormaPagamento;
                _dbContext.FormaPagamento.Update(formapagamento);
                await _dbContext.SaveChangesAsync();
            }
            return formapagamento;

        }

        public async Task<bool> DeleteFormaPagamento(int id)
        {
            FormaPagamentoModel FormaPagamento = await GetById(id);
            if (FormaPagamento == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.FormaPagamento.Remove(FormaPagamento);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}

