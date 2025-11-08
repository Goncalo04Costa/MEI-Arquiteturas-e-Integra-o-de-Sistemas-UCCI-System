using Microsoft.AspNetCore.Mvc;
using ConsultasService.Data;
using ConsultasService.Models;

namespace ConsultasService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsultasController : ControllerBase
    {
        private readonly ConsultasContext _context;

        public ConsultasController(ConsultasContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetConsultas() => Ok(_context.Consultas.ToList());

        [HttpGet("{id}")]
        public IActionResult GetConsulta(int id)
        {
            var consulta = _context.Consultas.Find(id);
            return consulta == null ? NotFound() : Ok(consulta);
        }

        [HttpPost]
        public IActionResult CreateConsulta([FromBody] Consulta consulta)
        {
            _context.Consultas.Add(consulta);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetConsulta), new { id = consulta.Id }, consulta);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateConsulta(int id, [FromBody] Consulta updated)
        {
            var consulta = _context.Consultas.Find(id);
            if (consulta == null) return NotFound();

            consulta.DataHora = updated.DataHora;
            consulta.FuncionarioId = updated.FuncionarioId;
            consulta.Estado = updated.Estado;
            consulta.Observacoes = updated.Observacoes;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConsulta(int id)
        {
            var consulta = _context.Consultas.Find(id);
            if (consulta == null) return NotFound();

            _context.Consultas.Remove(consulta);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
