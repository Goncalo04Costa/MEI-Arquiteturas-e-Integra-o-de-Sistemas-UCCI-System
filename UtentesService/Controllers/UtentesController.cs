// Controllers/UtentesController.cs
using Microsoft.AspNetCore.Mvc;
using UtentesService.Data;
using UtentesService.Models;

namespace UtentesService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UtentesController : ControllerBase
    {
        private readonly UtentesContext _context;

        public UtentesController(UtentesContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetUtentes() => Ok(_context.Utentes.ToList());

        [HttpPost]
        public IActionResult CreateUtente([FromBody] Utente utente)
        {
            _context.Utentes.Add(utente);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetUtentes), new { id = utente.Id }, utente);
        }
    }
}
