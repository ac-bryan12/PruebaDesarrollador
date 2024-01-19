namespace ReservaButacas.Server.Application.Exceptions
{
    public class ReservaNoEncontradaException: CustomException
    {
        public ReservaNoEncontradaException() : base("Err001", "La reserva no fue encontrada.")
        {
        }
    }
}
