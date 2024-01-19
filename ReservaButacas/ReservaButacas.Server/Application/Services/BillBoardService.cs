using ReservaButacas.Server.Application.Exceptions;
using ReservaButacas.Server.Domain.Interfaces.Repositories;
using ReservaButacas.Server.Domain.Interfaces.Services;
using System.Transactions;

namespace ReservaButacas.Server.Application.Services
{
    public class BillBoardService : IBillboardService
    {
        private readonly IBillboardRepository _billboardRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly ISeatRepository _seatRepository;

        public BillBoardService(IBillboardRepository billboardRepository, 
                                IBookingRepository bookingRepository, 
                                ISeatRepository seatRepository)
        {
            _billboardRepository = billboardRepository;
            _bookingRepository = bookingRepository;
            _seatRepository = seatRepository;
        }

        public void CancelarCartelera(int billboardId)
        {
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var cartelera = _billboardRepository.ObtenerCartelera(billboardId);

                    if (cartelera != null)
                    {
                        if (cartelera.Date < DateTime.Today)
                        {
                            throw new CarteleraFechaException();
                        }

                        var bookings = _bookingRepository.ObtenerReservasDeCartelera(cartelera.Id);

                        if (bookings != null && bookings.Any())
                        {
                            foreach (var booking in bookings)
                            {
                                _bookingRepository.CancelarReserva(booking.Id);
                                Console.WriteLine($"Cliente con cédula: {booking.CustomerId} afectado por la cancelación");
                            }

                            _billboardRepository.CancelarCartelera(cartelera.Id);
                            _seatRepository.HabilitarButacas(cartelera.RoomId);


                            transaction.Complete();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"No se pudo cancelar la reserva error: {ex.Message}");
                    throw new CarteleraException(ex);
                }
            }
        }
    }
}
