using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IPacienteRepositorio
    {
        Task<List<PacienteModel>> GetAll();

        Task<PacienteModel> GetById(int id);

        Task<PacienteModel> InsertPaciente(PacienteModel paciente);

        Task<PacienteModel> UpdatePaciente(PacienteModel paciente, int id);

        Task<bool> DeletePaciente(int id);
    }
}
