namespace ReservaButacas.Server.Application.Exceptions.Interfaces
{
    public interface ICustomException
    {
        string ErrorCode { get; }
        string ErrorMessage { get; }
    }
}
