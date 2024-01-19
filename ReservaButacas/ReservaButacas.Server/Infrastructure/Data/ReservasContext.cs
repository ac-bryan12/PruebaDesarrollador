using Microsoft.EntityFrameworkCore;
using ReservaButacas.Server.Domain.Entities;

namespace ReservaButacas.Server.Infrastructure.Data
{
    public class ReservasContext : DbContext
    {
        public ReservasContext(DbContextOptions<ReservasContext> options) : base(options)
        {
        }

        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<MovieEntity> Movies { get; set; }
        public DbSet<RoomEntity> Rooms { get; set; }
        public DbSet<SeatEntity> Seats { get; set; }
        public DbSet<BookingEntity> Bookings { get; set; }
        public  DbSet<BillboardEntity> Billboards { get; set; }  

        // Puedes agregar configuraciones adicionales aquí.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerEntity>()
                .HasIndex(c => c.DocumentNumber)
                .IsUnique();

        }
    }
}
