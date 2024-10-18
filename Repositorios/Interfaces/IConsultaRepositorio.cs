using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IConsultaRepositorio
    {
        Task<List<ConsultaModel>> GetAll();

        Task<ConsultaModel> GetById(int id);

        Task<ConsultaModel> InsertConsulta(ConsultaModel consulta);

        Task<ConsultaModel> UpdateConsulta(ConsultaModel consulta, int id);

        Task<bool> DeleteConsulta(int id);
    }
}
