using Microsoft.EntityFrameworkCore;
using ReservaButacas.Server.Domain.Entities;
using ReservaButacas.Server.Domain.Interfaces.Repositories;
using ReservaButacas.Server.Infrastructure.Data;
using ReservaButacas.Server.Infrastructure.ExternalServices;
using System.Linq;

namespace ReservaButacas.Server.Infrastructure.Repositories
{
    public class BillboardRepository : IBillboardRepository
    {

        private readonly ReservasContext _dbContext;
        public BillboardRepository(ReservasContext dbContext) { 
            _dbContext = dbContext;
        }
        public BillboardEntity ObtenerCartelera(int billboardId)
        {
            return _dbContext.Billboards.Where(b=>b.Id == billboardId).FirstOrDefault();
        }


        public void CancelarCartelera(int billboardId)
        {
            var cartelera = ObtenerCartelera(billboardId);
            if (cartelera != null)
            {
                cartelera.Status = false;
                _dbContext.SaveChanges();
            }

        }
    }
}
