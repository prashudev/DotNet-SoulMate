using Microsoft.EntityFrameworkCore;

namespace SoulMate.API.data 
{
    public class SoulmateDbContext : DbContext
    {
        public SoulmateDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Soulmate> Soulmate { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    Name = "India",
                    CountryCode = "IND"
                },
                    new Country
                    {
                        Id = 2,
                        Name = "United Kingdoms",
                        CountryCode = "UK"
                    }
                );
            modelBuilder.Entity<Soulmate>().HasData(
               new Soulmate
               {
                   Id = 1,
                   Name = "Alpha",
                   Age = 24,
                   Gender = "M",
                   CountryId = 2
               },
               new Soulmate
               {
                   Id = 2,
                   Name = "Beta",
                   Age = 25,
                   Gender = "M",
                   CountryId = 2
               },
               new Soulmate
               {
                   Id = 3,
                   Name = "Charliee",
                   Age = 23,
                   Gender = "F",
                   CountryId = 1
               },
               new Soulmate
               {
                   Id = 4,
                   Name = "zeta",
                   Age = 24,
                   Gender = "F",
                   CountryId = 1
               }
               );

        }
    }
}