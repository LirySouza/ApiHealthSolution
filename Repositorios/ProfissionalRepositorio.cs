using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositorios
{
    public class ProfissionalRepositorio : IProfissionalRepositorio
    {
        private readonly Contexto _dbContext;

        public ProfissionalRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ProfissionalModel>> GetAll()
        {
            return await _dbContext.Profissional.ToListAsync();
        }

        public async Task<ProfissionalModel> GetById(int id)
        {
            return await _dbContext.Profissional.FirstOrDefaultAsync(x => x.ProfissionalId == id);
        }

        public async Task<ProfissionalModel> InsertProfissional(ProfissionalModel Profissional)
        {
            await _dbContext.Profissional.AddAsync(Profissional);
            await _dbContext.SaveChangesAsync();
            return Profissional;
        }

        public async Task<ProfissionalModel> UpdateProfissional(ProfissionalModel requisicao, int id)
        {
            ProfissionalModel profissional = await GetById(id);
            if (profissional == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                profissional.NomeProfissional = requisicao.NomeProfissional;
                profissional.DataNascimento = requisicao.DataNascimento;
                profissional.TipoSexoId = requisicao.TipoSexoId;
                profissional.CpfProfissional = requisicao.CpfProfissional;
                profissional.EnderecoProfissional = requisicao.EnderecoProfissional;
                profissional.TipoProfissionalId = requisicao.TipoProfissionalId;
                _dbContext.Profissional.Update(profissional);
                await _dbContext.SaveChangesAsync();
            }
            return profissional;

        }

        public async Task<bool> DeleteProfissional(int id)
        {
            ProfissionalModel Profissional = await GetById(id);
            if (Profissional == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Profissional.Remove(Profissional);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
