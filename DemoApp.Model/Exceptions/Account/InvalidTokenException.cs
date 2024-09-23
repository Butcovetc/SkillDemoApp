using DemoApp.Model.Dal;

namespace DemoApp.Model.Exceptions.Account
{
    /// <summary>
    /// Invalid token exception
    /// </summary>
    internal class InvalidTokenException : BaseApiException
    {
        /// <summary>
        /// Invalid token exception
        /// </summary>
        public InvalidTokenException() : base(ErrorCodeEnum.AccountAreNotActive, "Invalid or not actual token")
        {
        }
    }
}