using BusinessLogic.MacrosCal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess.FoodData.Models
{
    public class FoodContext : DbContext
    {
        private readonly string _connectionString;

        public FoodContext(DbContextOptions<FoodContext> options, IConfiguration configuration)
            : base(options)
        {
            _connectionString = configuration.GetConnectionString("FoodDBConnectionString");
        }
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodMacro> FoodMacros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Food>(entity =>
            {
                entity.ToTable("Foods");
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<FoodMacro>(entity =>
            {
                entity.ToTable("FoodMacros");
                entity.Property(e => e.Quantity).IsRequired();
            });
            modelBuilder.Entity<FoodItem>(entity =>
            {
                entity.Property(e => e.Protein).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Carbs).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Fibre).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Fat).HasColumnType("decimal(18,2)");
                entity.Property(e => e.TotalCalories).HasColumnType("decimal(18,2)");
            });
        }
    }
}
