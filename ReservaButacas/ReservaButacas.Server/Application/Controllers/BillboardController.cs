using Microsoft.AspNetCore.Mvc;
using ReservaButacas.Server.Domain.Interfaces.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReservaButacas.Server.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillboardController : ControllerBase
    {
        private readonly IBillboardService _billboardService;

        public BillboardController(IBillboardService billboardService)
        {
            _billboardService = billboardService;
        }

        [HttpPost("{billboardId}/cancel")]
        public IActionResult CancelBillboardAndReservations(int billboardId)
        {
            try
            {
                _billboardService.CancelarCartelera(billboardId);
                return Ok("Cancelación de cartelera exitosa");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error durante la ejecución: {ex.Message}");
            }
        }
    }
}
