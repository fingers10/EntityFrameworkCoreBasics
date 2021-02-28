using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace EntityFrameworkCore
{
    public class EfCoreSqlServerContext : DbContext
    {
        public DbSet<CategoryEntity> Categories { get; set; }

        public DbSet<AnotherCategoryEntity> AnotherCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\;Database=EFCoreDB;Trusted_Connection=true;")
                          .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
                          .EnableDetailedErrors()
                          .EnableSensitiveDataLogging(false);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryEntity>(entity =>
            {
                entity.ToTable("Categories");
                entity.HasKey(e => e.Id);
                entity.Property(x => x.Name)
                      .HasComment("Name of the category")
                      .IsRequired()
                      .HasColumnType("varchar(200)");
                entity.Property(x => x.Desc)
                      .IsRequired(false)
                      .HasMaxLength(50)
                      .HasColumnName("Description");
                entity.Ignore(x => x.Status);
            });

            modelBuilder.Entity<AnotherCategoryEntity>(entity =>
            {
                entity.HasNoKey();
            });
        }
    }
}
