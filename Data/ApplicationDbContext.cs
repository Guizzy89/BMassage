using Microsoft.EntityFrameworkCore;
using BMassage.Models;

namespace BMassage.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        // Определяем наборы сущностей
        public DbSet<Massage> Massages { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Устанавливаем точную длину и масштаб для свойства Price
            modelBuilder.Entity<Massage>()
                        .Property(m => m.Price)
                        .HasColumnType("decimal(18,2)");
        }
    }
}