using ReservaButacas.Server.Domain.Entities;
using System.IO.Pipes;
using System.Linq.Expressions;

namespace ReservaButacas.Server.Domain.Interfaces.Services
{
    public interface ISeatService
    {
        bool InhabilitarButaca(int seatId);
        Dictionary<int, Dictionary<string, int>> InfoButacas();
    }
}
