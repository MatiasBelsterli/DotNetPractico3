using Microsoft.EntityFrameworkCore;
using DataAccessLayer.EFModels;

namespace DataAccessLayer {
    public class DBContextCore : DbContext{
        private readonly string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=practico1;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

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
