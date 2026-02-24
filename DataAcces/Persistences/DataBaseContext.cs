using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAcces.Persistences
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {
        }

        public DbSet<Regions> Regions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Regions>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Description)
                    .HasColumnName("Description");

                entity.Property(e => e.Departament)
                    .HasColumnName("Departament");
            });
        }
    }
}
