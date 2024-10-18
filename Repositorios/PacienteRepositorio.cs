using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositorios
{
    public class PacienteRepositorio : IPacienteRepositorio
    {
        private readonly Contexto _dbContext;

        public PacienteRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<PacienteModel>> GetAll()
        {
            return await _dbContext.Paciente.ToListAsync();
        }

        public async Task<PacienteModel> GetById(int id)
        {
            return await _dbContext.Paciente.FirstOrDefaultAsync(x => x.PacienteId == id);
        }

        public async Task<PacienteModel> InsertPaciente(PacienteModel Paciente)
        {
            await _dbContext.Paciente.AddAsync(Paciente);
            await _dbContext.SaveChangesAsync();
            return Paciente;
        }

        public async Task<PacienteModel> UpdatePaciente(PacienteModel paciente, int id)
        {
            PacienteModel pacientes = await GetById(id);
            if (paciente == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                pacientes.NomePaciente = paciente.NomePaciente;
                _dbContext.Paciente.Update(paciente);
                await _dbContext.SaveChangesAsync();
            }
            return pacientes;

        }

        public async Task<bool> DeletePaciente(int id)
        {
            PacienteModel Paciente = await GetById(id);
            if (Paciente == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Paciente.Remove(Paciente);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
