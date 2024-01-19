namespace ReservaButacas.Server.Application.Exceptions
{
    public class CarteleraFechaException : CustomException
    {
        public CarteleraFechaException() 
            : base("Err005", "No se puede cancelar funciones de la cartelera con fecha anterior a la actual.")
        {
        }
    }
}
