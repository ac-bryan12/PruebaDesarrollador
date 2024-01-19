namespace ReservaButacas.Server.Domain.Interfaces.Repositories
{
    public interface ISeatRepository
    {
        Dictionary<int, Dictionary<string, int>> ButacasDisponibles();
        void InhabilitarButacas(int roomId);
        void HabilitarButacas(int roomId);
    }
}
