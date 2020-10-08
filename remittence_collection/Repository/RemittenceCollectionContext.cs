using Microsoft.EntityFrameworkCore;
using remittence_collection.Models;

namespace remittence_collection.Repository
{
    public class RemittenceCollectionContext : DbContext
    {
        public RemittenceCollectionContext(DbContextOptions<RemittenceCollectionContext> options): base(options){}
        public DbSet<Country> Countries { get; set; }
        public DbSet<IDType> IDTypes { get; set; }
        public DbSet<ID> IDs { get; set; }
        public DbSet<RemitterType> RemitterTypes { get; set; }
        public DbSet<Remitter> Remitters { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Beneficiary> Beneficiaries { get; set; }
    }
}