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

        public async Task<ProfissionalModel> UpdateProfissional(ProfissionalModel profissional, int id)
        {
            ProfissionalModel profissionais = await GetById(id);
            if (profissional == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                profissionais.NomeProfissional = profissional.NomeProfissional;
                _dbContext.Profissional.Update(profissional);
                await _dbContext.SaveChangesAsync();
            }
            return profissionais;

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
