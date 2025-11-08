// Models/Utente.cs
namespace UtentesService.Models
{
    public class Utente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NIF { get; set; }
        public string Telefone { get; set; }
        public string Responsavel { get; set; }
    }
}
