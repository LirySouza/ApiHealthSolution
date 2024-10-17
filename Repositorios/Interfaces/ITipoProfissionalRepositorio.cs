using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface ITipoProfissionalRepositorio
    {
        Task<List<TipoProfissionalModel>> GetAll();

        Task<TipoProfissionalModel> GetById(int id);

        Task<TipoProfissionalModel> InsertTipoProfissional(TipoProfissionalModel tipoprofissional);

        Task<TipoProfissionalModel> UpdateTipoProfissional(TipoProfissionalModel tipoprofissional, int id);

        Task<bool> DeleteTipoProfissional(int id);
    }
}
