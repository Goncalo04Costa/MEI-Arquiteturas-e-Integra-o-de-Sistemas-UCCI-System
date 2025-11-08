// Controllers/FuncionariosController.cs
using Microsoft.AspNetCore.Mvc;
using FuncionariosService.Data;
using FuncionariosService.Models;

namespace FuncionariosService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FuncionariosController : ControllerBase
    {
        private readonly FuncionariosContext _context;

        public FuncionariosController(FuncionariosContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetFuncionarios() => Ok(_context.Funcionarios.ToList());

        [HttpPost]
        public IActionResult CreateFuncionario([FromBody] Funcionario funcionario)
        {
            _context.Funcionarios.Add(funcionario);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetFuncionarios), new { id = funcionario.Id }, funcionario);
        }
    }
}
