using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Api.Repositorios
{
    public class TipoConsultaRepositorio : ITipoConsultaRepositorio
    {
        private readonly Contexto _dbContext;

        public TipoConsultaRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TipoConsultaModel>> GetAll()
        {
            return await _dbContext.TipoConsulta.ToListAsync();
        }

        public async Task<TipoConsultaModel> GetById(int id)
        {
            return await _dbContext.TipoConsulta.FirstOrDefaultAsync(x => x.TipoConsultaId == id);
        }

        public async Task<TipoConsultaModel> InsertTipoConsulta(TipoConsultaModel TipoConsulta)
        {
            await _dbContext.TipoConsulta.AddAsync(TipoConsulta);
            await _dbContext.SaveChangesAsync();
            return TipoConsulta;
        }

        public async Task<TipoConsultaModel> UpdateTipoConsulta(TipoConsultaModel requisicao, int id)
        {
            TipoConsultaModel tipoconsulta = await GetById(id);
            if (tipoconsulta == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {            
                tipoconsulta.TipoConsultaId = requisicao.TipoConsultaId;
                tipoconsulta.NomeTipoConsulta = requisicao.NomeTipoConsulta;
                _dbContext.TipoConsulta.Update(tipoconsulta);
                await _dbContext.SaveChangesAsync();
            }
            return tipoconsulta;

        }

        public async Task<bool> DeleteTipoConsulta(int id)
        {
            TipoConsultaModel TipoConsulta = await GetById(id);
            if (TipoConsulta == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.TipoConsulta.Remove(TipoConsulta);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}

