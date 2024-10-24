using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositorios
{
    public class TipoProfissionalRepositorio : ITipoProfissionalRepositorio
    {
        private readonly Contexto _dbContext;

        public TipoProfissionalRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TipoProfissionalModel>> GetAll()
        {
            return await _dbContext.TipoProfissional.ToListAsync();
        }

        public async Task<TipoProfissionalModel> GetById(int id)
        {
            return await _dbContext.TipoProfissional.FirstOrDefaultAsync(x => x.TipoProfissionalId == id);
        }

        public async Task<TipoProfissionalModel> InsertTipoProfissional(TipoProfissionalModel TipoProfissional)
        {
            await _dbContext.TipoProfissional.AddAsync(TipoProfissional);
            await _dbContext.SaveChangesAsync();
            return TipoProfissional;
        }

        public async Task<TipoProfissionalModel> UpdateTipoProfissional(TipoProfissionalModel requisicao, int id)
        {
            TipoProfissionalModel tipoprofissional = await GetById(id);
            if (tipoprofissional == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                tipoprofissional.NomeTipoProfissional = requisicao.NomeTipoProfissional;
                _dbContext.TipoProfissional.Update(tipoprofissional);
                await _dbContext.SaveChangesAsync();
            }
            return tipoprofissional;

        }

        public async Task<bool> DeleteTipoProfissional(int id)
        {
            TipoProfissionalModel TipoProfissional = await GetById(id);
            if (TipoProfissional == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.TipoProfissional.Remove(TipoProfissional);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
