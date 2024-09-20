using DemoApp.Model.Dal;

namespace DemoApp.Model.Exceptions
{
    /// <summary>
    /// Base class for all critical exception 
    /// </summary>
    public class BaseCriticalException : DemoAppException
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="errorCode">Error code</param>
        public BaseCriticalException(ErrorCodeEnum errorCode) : base(errorCode)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="errorCode">Error code</param>
        /// <param name="message">Message text</param>
        public BaseCriticalException(ErrorCodeEnum errorCode, string message) : base(errorCode, message)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="errorCode">Error code</param>
        /// <param name="message">Message text</param>
        /// <param name="innerException">Inner exception</param>
        public BaseCriticalException(ErrorCodeEnum errorCode, string message, Exception innerException) : base(errorCode, message, innerException)
        {
        }
    }
}
