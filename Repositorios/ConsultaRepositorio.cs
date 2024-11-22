using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Api.Repositorios
{
    public class ConsultaRepositorio : IConsultaRepositorio
    {
        private readonly Contexto _dbContext;

        public ConsultaRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ConsultaModel>> GetAll()
        {
            return await _dbContext.Consulta.ToListAsync();
        }

        public async Task<ConsultaModel> GetById(int id)
        {
            return await _dbContext.Consulta.FirstOrDefaultAsync(x => x.ConsultaId == id);
        }

        public async Task<ConsultaModel> InsertConsulta(ConsultaModel Consulta)
        {
            await _dbContext.Consulta.AddAsync(Consulta);
            await _dbContext.SaveChangesAsync();
            return Consulta;
        }

        public async Task<ConsultaModel> UpdateConsulta(ConsultaModel requisicao, int id)
        {
            ConsultaModel consulta = await GetById(id);
            if (consulta == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {            
                consulta.PacienteId = requisicao.PacienteId;
                consulta.ObsConsulta = requisicao.ObsConsulta;
                consulta.ProfissionalId = requisicao.ProfissionalId;
                consulta.DataConsulta = requisicao.DataConsulta;
                _dbContext.Consulta.Update(consulta);
                await _dbContext.SaveChangesAsync();
            }
            return consulta;

        }

        public async Task<bool> DeleteConsulta(int id)
        {
            ConsultaModel Consulta = await GetById(id);
            if (Consulta == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Consulta.Remove(Consulta);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}

