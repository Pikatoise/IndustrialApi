using Loading.DAL.Configurations;
using Loading.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Loading.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            //Database.EnsureDeleted();

            Database.EnsureCreated();
        }

        public DbSet<RegionType> RegionTypes { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RegionTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RegionConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new ManufacturerConfiguration());
            modelBuilder.ApplyConfiguration(new EquipmentConfiguration());
        }
    }
}
