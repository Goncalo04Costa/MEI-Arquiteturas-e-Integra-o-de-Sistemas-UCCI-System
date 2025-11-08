// Data/FuncionariosContext.cs
using FuncionariosService.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FuncionariosService.Data
{
    public class FuncionariosContext : DbContext
    {
        public FuncionariosContext(DbContextOptions<FuncionariosContext> options) : base(options) { }
        public DbSet<Funcionario> Funcionarios { get; set; }
    }
}
