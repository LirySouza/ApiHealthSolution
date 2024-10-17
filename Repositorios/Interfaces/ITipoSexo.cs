using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface ITipoSexoRepositorio
    {
        Task<List<TipoSexoModel>> GetAll();

        Task<TipoSexoModel> GetById(int id);

        Task<TipoSexoModel> InsertTipoSexo(TipoSexoModel tiposexo);

        Task<TipoSexoModel> UpdateTipoSexo(TipoSexoModel tiposexo, int id);

        Task<bool> DeleteTipoSexo(int id);
    }
}

