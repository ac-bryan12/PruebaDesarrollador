using Microsoft.EntityFrameworkCore;
using ReservaButacas.Server.Application.Exceptions;
using ReservaButacas.Server.Domain.Entities;
using ReservaButacas.Server.Domain.Interfaces.Repositories;
using ReservaButacas.Server.Domain.Interfaces.Services;
using System.Transactions;

namespace ReservaButacas.Server.Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly ISeatRepository _seatRepository;
        public BookingService(IBookingRepository bookingRepository, ISeatRepository seatRepository) { 
            _bookingRepository = bookingRepository;
            _seatRepository = seatRepository;
        }
        public void CancelarReserva(int bookingId)
        {
            try
            {
                using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var booking = _bookingRepository.ObtenerReserva(bookingId);
                    if (booking == null)
                    {
                        throw new ReservaNoEncontradaException();
                    }
                    _bookingRepository.CancelarReserva(bookingId);
                    _seatRepository.InhabilitarButacas(booking.SeatId);

                    transaction.Complete();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"No se pudo cancelar la reserva error: {ex.Message}");
                throw new ReservaException(ex);
            }

        }

        public IEnumerable<BookingEntity> Reservas_Terror_Fechas(DateTime startDate, DateTime endDate)
        {
            var reservas = _bookingRepository.Reservas_Terror_Fechas(startDate, endDate);
            if (reservas != null && reservas.Count() > 0){ return reservas; }
            else { return Enumerable.Empty<BookingEntity>(); }
        }

        
    }
}
