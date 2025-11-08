// Data/UtentesContext.cs
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using UtentesService.Models;

namespace UtentesService.Data
{
    public class UtentesContext : DbContext
    {
        public UtentesContext(DbContextOptions<UtentesContext> options) : base(options) { }
        public DbSet<Utente> Utentes { get; set; }
    }
}
