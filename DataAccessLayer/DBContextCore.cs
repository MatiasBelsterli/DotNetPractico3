using Microsoft.EntityFrameworkCore;
using DataAccessLayer.EFModels;

namespace DataAccessLayer {
    public class DBContextCore : DbContext{
        private string _connectionString = "Server=sqlserver,1433;Database=Practico1;User Id=sa;Password=Abc*123!;Encrypt=False;";
        public DBContextCore() { }

        public DBContextCore(DbContextOptions<DBContextCore> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Personas> Personas { get; set; }

        public DbSet<Vehiculos> Vehiculos { get; set; }
    }
}
