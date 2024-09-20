using DemoApp.Model.Dal;

namespace DemoApp.Model.Exceptions.Api
{
    /// <summary>
    /// Wrong argument exception
    /// </summary>
    public class WrongArgumentException : BaseApiException
    {
        /// <summary>
        /// Constuctor
        /// </summary>
        /// <param name="message">Message</param>
        public WrongArgumentException(string message) 
            : base(ErrorCodeEnum.WrongArgumentException,message) 
        { }

        /// <summary>
        /// Constuctor
        /// </summary>
        public WrongArgumentException() : base(ErrorCodeEnum.WrongArgumentException)
        { }
    }
}
