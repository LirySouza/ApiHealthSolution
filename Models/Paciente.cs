namespace Api.Models
{
    public class PacienteModel
    {
        public int PacienteId { get; set; }
        public string NomePaciente { get; set; } = string.Empty;
        public string DataNascimento  { get; set; } = string.Empty;
        public int TipoSexoId { get; set; }
        public int CpfPaciente { get; set; }
        public string EnderecoPaciente { get; set; } = string.Empty;
        public int TelefonePaciente { get; set; }
    }
}
