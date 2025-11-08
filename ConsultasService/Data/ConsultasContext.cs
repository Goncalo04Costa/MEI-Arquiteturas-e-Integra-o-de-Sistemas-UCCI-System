using ConsultasService.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ConsultasService.Data
{
    public class ConsultasContext : DbContext
    {
        public ConsultasContext(DbContextOptions<ConsultasContext> options) : base(options) { }

        public DbSet<Consulta> Consultas { get; set; }
    }
}
