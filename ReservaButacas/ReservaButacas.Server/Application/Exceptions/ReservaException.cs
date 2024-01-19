namespace ReservaButacas.Server.Application.Exceptions
{
    public class ReservaException : CustomException
    {
        public ReservaException(Exception innerException)
        : base("Err002", "Error al cancelar la reserva.", innerException)
        {
        }
    }
}
