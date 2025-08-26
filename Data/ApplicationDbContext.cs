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
    }
}