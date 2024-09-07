using Microsoft.EntityFrameworkCore;
using Pets.Entities;

namespace Pets
{
    public class OwnerInfoContext : DbContext
    {
        public OwnerInfoContext(DbContextOptions<OwnerInfoContext> options) : base(options) { }

        // Register Db Models!
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pet> Pets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Owner>().HasData
                (
                    new Owner { Id = 1, Name = "Jhon" },
                    new Owner { Id = 2, Name = "Samuel" }
                );

            modelBuilder.Entity<Pet>().HasData
                (
                    new Pet { Id = 1, Name = "Ezreal", Birthdate = DateTime.Now, OwnerId = 1 },
                    new Pet { Id = 2, Name = "Seraphine", Birthdate = DateTime.Now, OwnerId = 2 },
                    new Pet { Id = 3, Name = "Varus", Birthdate = DateTime.Now, OwnerId = 2 }
                );
        }
    }
}
