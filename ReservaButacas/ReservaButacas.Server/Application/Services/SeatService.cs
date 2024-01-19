using ReservaButacas.Server.Domain.Interfaces.Repositories;
using ReservaButacas.Server.Domain.Interfaces.Services;

namespace ReservaButacas.Server.Application.Services
{
    public class SeatService : ISeatService
    {
        private ISeatRepository _seatRepository;

        public SeatService(ISeatRepository seatRepository)
        {
            _seatRepository = seatRepository;
        }

        public bool InhabilitarButaca(int seatId)
        {
            try
            {
                _seatRepository.InhabilitarButacas(seatId);
                return true;

            }
            catch (Exception ex)
            {
                Console.Write($"No se pudo inhabilitar la butaca error: {ex.Message}");
                return false;
            }
        }

        public Dictionary<int, Dictionary<string, int>> InfoButacas()
        {
            var butacas = _seatRepository.ButacasDisponibles();
            if ( butacas != null)
            {
                return butacas;
            }
            return new Dictionary<int, Dictionary<string, int>>();
        }
    }
}
