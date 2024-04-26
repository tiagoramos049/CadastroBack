using Microsoft.EntityFrameworkCore;

namespace CadastroBack.Models
{
    public class Contexto : DbContext
    {
        public DbSet<Cadastro> Cadastros { get; set; }
        public Contexto(DbContextOptions<Contexto> opcoes): base(opcoes)
        {
            
        }
    }
}
