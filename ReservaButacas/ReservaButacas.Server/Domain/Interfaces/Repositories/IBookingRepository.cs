using ReservaButacas.Server.Domain.Entities;

namespace ReservaButacas.Server.Domain.Interfaces.Repositories
{
    public interface IBookingRepository
    {
        void CancelarReserva(int bookingId);
        BookingEntity ObtenerReserva(int id);
        List<BookingEntity> ObtenerReservasDeCartelera(int carteleraId);
        IEnumerable<BookingEntity> Reservas_Terror_Fechas(DateTime f_inicio, DateTime f_final);

    }
}
