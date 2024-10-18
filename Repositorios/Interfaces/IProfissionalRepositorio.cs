using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IProfissionalRepositorio
    {
        Task<List<ProfissionalModel>> GetAll();

        Task<ProfissionalModel> GetById(int id);

        Task<ProfissionalModel> InsertProfissional(ProfissionalModel profissional);

        Task<ProfissionalModel> UpdateProfissional(ProfissionalModel profissional, int id);

        Task<bool> DeleteProfissional(int id);
    }
}
