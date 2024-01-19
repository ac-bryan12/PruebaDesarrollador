using Microsoft.EntityFrameworkCore;
using ReservaButacas.Server.Domain.Entities;
using ReservaButacas.Server.Domain.Enums;
using ReservaButacas.Server.Domain.Interfaces.Repositories;
using ReservaButacas.Server.Infrastructure.Data;

namespace ReservaButacas.Server.Infrastructure.ExternalServices
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ReservasContext _dbContext;

        public BookingRepository(ReservasContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<BookingEntity> GetBookings()
        {
            return _dbContext.Bookings.ToList();
        }

        public BookingEntity ObtenerReserva(int id)
        {
            return _dbContext.Bookings.FirstOrDefault(booking => booking.Id == id);
        }

        public void AddBooking(BookingEntity booking)
        {
            if (booking == null) throw new ArgumentNullException(nameof(booking));
            _dbContext.Bookings.Add(booking);
            _dbContext.SaveChanges();
        }

        public bool UpdateBooking(BookingEntity booking)
        {
            var existingBooking = _dbContext.Bookings.FirstOrDefault(b => b.Id == booking.Id);
            if (existingBooking != null)
            {
                existingBooking.Date = booking.Date;
                existingBooking.Seat = booking.Seat;
                existingBooking.SeatId = booking.SeatId;
                existingBooking.BillboardId = booking.BillboardId;
                existingBooking.Billboard = booking.Billboard;
                _dbContext.SaveChanges();
                return true;
            }

            return false;
        }

        public void RemoveBooking(int bookingId)
        {
            var bookingToRemove = _dbContext.Bookings.FirstOrDefault(booking => booking.Id == bookingId);
            if (bookingToRemove != null)
            {
                _dbContext.Bookings.Remove(bookingToRemove);
                _dbContext.SaveChanges();
            }
        }

        //Generar el query necesario para obtener las reservas de películas cuyo genero sea terror y con un rango de fechas
        public IEnumerable<BookingEntity> Reservas_Terror_Fechas(DateTime f_inicio, DateTime f_final)
        {
            return _dbContext.Bookings
                .Where(booking =>
                    booking.Billboard.Movie.Genre == MovieGenreEnum.HORROR &&
                    booking.Billboard.Date >= f_inicio.Date &&
                    booking.Billboard.Date <= f_final.Date)
                .ToList();

        }

        public void CancelarReserva(int bookingId)
        {
            var booking =  _dbContext.Bookings.Where(b=>b.Id == bookingId).FirstOrDefault();
            if(booking != null)
            {
                booking.Status = false;
                var Seat = _dbContext.Seats.Where(b=>b.Id == booking.SeatId).FirstOrDefault();
                Seat.Status = false;
                _dbContext.SaveChanges();
            }
        }

        public  List<BookingEntity> ObtenerReservasDeCartelera(int carteleraId)
        {
            var lista =_dbContext.Bookings
                .Where(b => b.BillboardId == carteleraId)
                .ToList();
            if (lista != null)
            {
                return lista;
            }
            return new List<BookingEntity>();
        }
    }
}

