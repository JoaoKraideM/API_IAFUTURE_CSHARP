using Database.Mappings;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Database
{
    public class APIDbContext : DbContext
    {
        public DbSet<Conta> Contas { get; set; }
        public DbSet<FeedbackCliente> FeedbacksCliente { get; set; }
        public DbSet<InteracaoCliente> InteracoesCliente { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ResultadoIA> ResultadosIA { get; set; }


        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContaMapping());
            modelBuilder.ApplyConfiguration(new ClienteMapping());
            modelBuilder.ApplyConfiguration(new FeedbackMapping());
            modelBuilder.ApplyConfiguration(new InteracaoMapping());
            modelBuilder.ApplyConfiguration(new ResultadoMapping());

            base.OnModelCreating(modelBuilder);
        }
    }

}

