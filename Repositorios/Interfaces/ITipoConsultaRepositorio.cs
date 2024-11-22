using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface ITipoConsultaRepositorio
    {
        Task<List<TipoConsultaModel>> GetAll();

        Task<TipoConsultaModel> GetById(int id);

        Task<TipoConsultaModel> InsertTipoConsulta(TipoConsultaModel tipoconsulta);

        Task<TipoConsultaModel> UpdateTipoConsulta(TipoConsultaModel tipoconsulta, int id);

        Task<bool> DeleteTipoConsulta(int id);
    }
}

