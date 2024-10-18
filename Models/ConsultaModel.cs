namespace Api.Models
{
    public class ConsultaModel
    {
        public int ConsultaId { get; set; }

        public string NomeConsulta { get; set; } = string.Empty;

        public int PacienteId { get; set; }

        public string ObsConsulta { get; set; } = string.Empty;

        public int ProfissionalId { get; set; }

        public DateTime DataConsulta { get; set; }
    }
}
