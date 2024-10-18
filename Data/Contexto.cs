using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        public DbSet<UsersModel> User { get; set; }
        public DbSet<TipoProfissionalModel> TipoProfissional { get; set; }

        public DbSet<TipoSexoModel> TipoSexo { get; set; }
        public DbSet<PacienteModel> Paciente { get; set; }
        public DbSet<PagamentoModel> Pagamento { get; set; }
        public DbSet<ProfissionalModel> Profissional { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsersMap());
            modelBuilder.ApplyConfiguration(new TipoProfissionalMap());
            modelBuilder.ApplyConfiguration(new TipoSexoMap());
            modelBuilder.ApplyConfiguration(new PacienteMap());
            modelBuilder.ApplyConfiguration(new PagamentolMap());
            modelBuilder.ApplyConfiguration(new ProfissionalMap());
            base.OnModelCreating(modelBuilder);
        }

    }
}
