using Microsoft.EntityFrameworkCore;
using RelicarioApplication.Models;

namespace RelicarioApplication.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }


        public DbSet<ProfessorModel> TB_PROFESSORES { get; set; }
        public DbSet<AlunoModel> TB_ALUNOS { get; set; }
        //public DbSet<EnderecoModel> TB_ENDERECOS { get; set; }
       // public DbSet<AtividadeModel> TB_ATIVIDADES { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            
        } 
    }
}


