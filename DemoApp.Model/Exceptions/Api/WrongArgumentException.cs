using DemoApp.Model.Dal;

namespace DemoApp.Model.Exceptions.Api
{
    /// <summary>
    /// Wrong argument exception
    /// </summary>
    internal class WrongArgumentException : BaseApiException
    {
        /// <summary>
        /// Constuctor
        /// </summary>
        /// <param name="message">Message</param>
        public WrongArgumentException(string message) 
            : base(ErrorCodeEnum.WrongArgumentException,message) 
        { }
    }
}
