using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositorios
{
    public class TipoSexoRepositorio : ITipoSexoRepositorio
    {
        private readonly Contexto _dbContext;

        public TipoSexoRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TipoSexoModel>> GetAll()
        {
            return await _dbContext.TipoSexo.ToListAsync();
        }

        public async Task<TipoSexoModel> GetById(int id)
        {
            return await _dbContext.TipoSexo.FirstOrDefaultAsync(x => x.TipoSexoId == id);
        }

        public async Task<TipoSexoModel> InsertTipoSexo(TipoSexoModel TipoSexo)
        {
            await _dbContext.TipoSexo.AddAsync(TipoSexo);
            await _dbContext.SaveChangesAsync();
            return TipoSexo;
        }

        public async Task<TipoSexoModel> UpdateTipoSexo(TipoSexoModel tiposexo, int id)
        {
            TipoSexoModel tiposexos = await GetById(id);
            if (tiposexos == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                tiposexos.NomeTipoSexo = tiposexo.NomeTipoSexo;
                _dbContext.TipoSexo.Update(tiposexo);
                await _dbContext.SaveChangesAsync();
            }
            return tiposexo;

        }

        public async Task<bool> DeleteTipoSexo(int id)
        {
            TipoSexoModel TipoSexo = await GetById(id);
            if (TipoSexo == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.TipoSexo.Remove(TipoSexo);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}

