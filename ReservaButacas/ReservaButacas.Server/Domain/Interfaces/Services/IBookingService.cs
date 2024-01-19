using ReservaButacas.Server.Domain.Entities;

namespace ReservaButacas.Server.Domain.Interfaces.Services
{
    public interface IBookingService
    {
        IEnumerable<BookingEntity> Reservas_Terror_Fechas(DateTime startDate, DateTime endDate);
        void CancelarReserva(int bookingId);
    }
}
