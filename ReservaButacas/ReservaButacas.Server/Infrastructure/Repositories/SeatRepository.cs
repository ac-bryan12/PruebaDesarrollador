using Microsoft.EntityFrameworkCore;
using ReservaButacas.Server.Domain.Interfaces.Repositories;
using ReservaButacas.Server.Infrastructure.Data;

namespace ReservaButacas.Server.Infrastructure.ExternalServices
{
    public class SeatRepository : ISeatRepository
    {
        private readonly ReservasContext _dbContext;

        public SeatRepository(ReservasContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void InhabilitarButacas(int seatId)
        {
            try
            {
                var seat = _dbContext.Seats.FirstOrDefault(s => s.Id == seatId);

                if (seat != null)
                {
                    seat.Status = false;
                    _dbContext.SaveChanges();
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public void HabilitarButacas(int roomId)
        {
            var seats =  _dbContext.Seats
                .Where(s => s.RoomId == roomId)
                .ToList();

            foreach (var seat in seats)
            {
                seat.Status = true;
            }
            _dbContext.SaveChanges();
        }


        //Generar el query necesario para obtener el numero de butacas disponibles y ocupadas por sala en la cartelera del día actual.
        public Dictionary<int, Dictionary<string, int>> ButacasDisponibles()
        {
            
            var Info = _dbContext.Rooms
                .Select(room => new
                {
                    Room = room,
                    ButacasInfo = new Dictionary<string, int>
                    {
                        { "ButacasOcupadas", _dbContext.Bookings.Count(b => b.Billboard.RoomId == room.Id && b.Billboard.Date.Date == DateTime.Today.Date) },
                        { "ButacasDisponibles", _dbContext.Seats.Count(s => s.RoomId == room.Id)  - _dbContext.Bookings.Count(b => b.Billboard.RoomId == room.Id && b.Billboard.Date == DateTime.Today) }
                    }
                            })
                .ToDictionary(
                    item => item.Room.Id,
                    item => item.ButacasInfo
                );

            return Info;
        }
    }
}
