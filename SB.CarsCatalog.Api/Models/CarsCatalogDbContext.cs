using Microsoft.EntityFrameworkCore;

namespace SB.CarsCatalog.Api.Models
{
    /// <summary>
    /// Cars Catalog db Context
    /// </summary>
    public class CarsCatalogDbContext : DbContext
    {
        /// <summary>
        /// Cars Catalog db Context ctor
        /// </summary>
        /// <param name="options"></param>
        public CarsCatalogDbContext(DbContextOptions<CarsCatalogDbContext> options) 
            : base(options)
        { }

        /// <summary>
        /// Brands set
        /// </summary>
        public DbSet<Brand> Brands { get; set; }
        /// <summary>
        /// Models set
        /// </summary>
        public DbSet<Model> Models { get; set; }
        /// <summary>
        /// Users set
        /// </summary>
        public DbSet<User> Users { get; set; }
        /// <summary>
        /// Configure table relations
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>()
                .HasMany(b => b.Models)
                .WithOne(m => m.Brand)
                .HasForeignKey(m => m.BrandId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
