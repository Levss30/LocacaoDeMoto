using Microsoft.EntityFrameworkCore;
using MottuDesafio.Models;

namespace MottuDesafio.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }

        public DbSet<Entregador> Entregador { get; set; }
        public DbSet<Moto> Motos { get; set; }
        public DbSet<Locacao> Locacaos { get; set; }
    }
}