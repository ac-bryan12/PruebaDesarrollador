namespace ReservaButacas.Server.Application.Exceptions
{
    public class CarteleraException : CustomException
    {
        public CarteleraException(Exception innerException) 
            : base("Err004", "Error al cancelar la cartelera.", innerException)
        {
        }
    }
}
