namespace ReservaButacas.Server.Application.Exceptions
{
    public class FechaInvalidaException : CustomException
    {
        public FechaInvalidaException(string message) : base("Err003", message)
        {
        }
    }
}
