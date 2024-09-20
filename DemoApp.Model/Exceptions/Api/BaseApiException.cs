using DemoApp.Model.Dal;

namespace DemoApp.Model.Exceptions.Api
{
    /// <summary>
    /// Base class for all exceptions
    /// </summary>
    public class BaseApiException:Exception
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public BaseApiException() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Error message</param>
        public BaseApiException(string message) : base(message) { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="errorCode">Exception error code</param>
        /// <param name="message">Exception error message</param>
        public BaseApiException(ErrorCodeEnum errorCode, string message) : base(message) { }

        /// <summary>
        /// Exception related error code
        /// </summary>
        protected ErrorCodeEnum ErrorCode { get; set; }

    }
}
