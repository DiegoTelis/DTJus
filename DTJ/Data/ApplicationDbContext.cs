using DTJ.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DTJ.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Pessoa> Pessoas{ get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<ContasAReceber> Recebimentos { get; set; }
        public DbSet<Feriado> Feriados{ get; set; }

    }
}
