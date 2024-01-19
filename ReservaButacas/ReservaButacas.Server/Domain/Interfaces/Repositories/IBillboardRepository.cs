using ReservaButacas.Server.Domain.Entities;

namespace ReservaButacas.Server.Domain.Interfaces.Repositories
{
    public interface IBillboardRepository
    {
        BillboardEntity ObtenerCartelera(int billboard);
        void CancelarCartelera(int billboardId);
    }
}
