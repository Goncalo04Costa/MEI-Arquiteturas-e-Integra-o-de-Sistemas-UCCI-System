// Models/Funcionario.cs
namespace FuncionariosService.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public bool Disponivel { get; set; } = true;
    }
}
