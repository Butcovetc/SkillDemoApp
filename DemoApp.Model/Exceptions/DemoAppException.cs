using DemoApp.Model.Dal;

namespace DemoApp.Model.Exceptions
{
    /// <summary>
    /// Demo app exception
    /// </summary>
    public class DemoAppException : Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="errorCode">Exception error code</param>
        /// <param name="message">Exception error message</param>
        public DemoAppException(ErrorCodeEnum errorCode) : base()
            => ErrorCode = errorCode;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="errorCode">Exception error code</param>
        /// <param name="message">Exception error message</param>
        public DemoAppException(ErrorCodeEnum errorCode, string message) : base(message)
            => ErrorCode = errorCode;

        /// <summary>
        /// Exception related error code
        /// </summary>
        public ErrorCodeEnum ErrorCode { get; protected set; }
    }
}
