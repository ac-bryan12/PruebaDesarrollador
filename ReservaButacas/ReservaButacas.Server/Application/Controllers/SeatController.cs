using Microsoft.AspNetCore.Mvc;
using ReservaButacas.Server.Domain.Interfaces.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReservaButacas.Server.Application.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SeatController : ControllerBase
    {

        private readonly ISeatService _seatService;

        public SeatController(ISeatService seatService)
        {
            _seatService = seatService;
        }
        [HttpPost("{seatId}/disable")]
        public IActionResult InhabilitarButaca(int seatId)
        {
            try
            {
                _seatService.InhabilitarButaca(seatId);
                return Ok("Inhabilitación exitosa");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error durante la ejecución: {ex.Message}");
            }
        }

        [HttpGet("/InfoButacas")]

        public IActionResult InfoButacas()
        {
            try
            {
                var diccionario = _seatService.InfoButacas();
                return Ok(new OkObjectResult(diccionario));
            }
            catch (Exception ex)
            {
                return BadRequest($"Error durante la ejecución: {ex.Message}");
            }
        }
    }
}
