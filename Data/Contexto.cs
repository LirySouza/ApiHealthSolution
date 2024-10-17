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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsersMap());
            modelBuilder.ApplyConfiguration(new TipoProfissionalMap());
            modelBuilder.ApplyConfiguration(new TipoSexoMap());
            base.OnModelCreating(modelBuilder);
        }

    }
}
