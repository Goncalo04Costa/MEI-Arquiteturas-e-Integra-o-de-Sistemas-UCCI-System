namespace ConsultasService.Models
{
    public class Consulta
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public int UtenteId { get; set; }
        public int? FuncionarioId { get; set; }
        public string Estado { get; set; } = "Agendada";
        public string? Observacoes { get; set; }
    }
}
