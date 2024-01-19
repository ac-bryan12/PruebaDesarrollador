using Microsoft.AspNetCore.Mvc;
using ReservaButacas.Server.Domain.Interfaces.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReservaButacas.Server.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost("{bookingId}/cancel")]
        public IActionResult CancelBooking(int bookingId)
        {
            try
            {
                _bookingService.CancelarReserva(bookingId);
                return Ok("Cancelación de reserva exitosa");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error durante la ejecución: {ex.Message}");
            }
        }

        [HttpGet("/ReservasTerrorPorFecha")]
        public IActionResult ReservasTerrorPorFecha(DateTime f_inicio, DateTime f_final)
        {
            try
            {
                _bookingService.Reservas_Terror_Fechas(f_inicio, f_final);
                return Ok("Cancelación de reserva exitosa");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error durante la ejecución: {ex.Message}");
            }
        }
    }
}
