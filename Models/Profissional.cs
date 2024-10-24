namespace Api.Models
{
    public class ProfissionalModel
    {
        public int ProfissionalId { get; set; }
        public string NomeProfissional { get; set; } = string.Empty;
        public string DataNascimentoProfissional  { get; set; } = string.Empty;
        public int TipoSexoId { get; set; }
        public int CpfProfissional { get; set; }
        public string EnderecoProfissional { get; set; } = string.Empty;
        public int TipoProfissionalId { get; set; }
    }
}
