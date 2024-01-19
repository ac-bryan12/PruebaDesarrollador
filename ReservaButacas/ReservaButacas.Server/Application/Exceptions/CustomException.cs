using ReservaButacas.Server.Application.Exceptions.Interfaces;

namespace ReservaButacas.Server.Application.Exceptions
{
    public abstract class CustomException : Exception, ICustomException
    {
        public string ErrorCode { get; }
        public string ErrorMessage { get; }


        protected CustomException(string errorCode, string message)
        : base(message)
        {
            ErrorCode = errorCode;
            ErrorMessage = message;
        }
        protected CustomException(string errorCode, string message, Exception innerException)
        : base(message, innerException)
        {
            ErrorCode = errorCode;
            ErrorMessage = message;
        }

    }

}
