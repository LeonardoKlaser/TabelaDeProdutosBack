using APIweb.Models;
using Microsoft.EntityFrameworkCore;

namespace APIweb.Data
{
    public class AppDbContext : DbContext
    {
        
        public DbSet<Produto> Products { get; set; } //mapeamento da tabela

      
       // public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //Realiza a conexão com o banco de dados
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("server=localhost;" +
                "Port=5432; Database=TabelaDeProdutos;" +
                "User Id=postgres;" +
                "Password=1234");

    }
}