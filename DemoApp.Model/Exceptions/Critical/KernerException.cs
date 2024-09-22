
using DemoApp.Model.Dal;

namespace DemoApp.Model.Exceptions.Critical
{
    /// <summary>
    /// Application kernel exception
    /// </summary>
    public class KernerException : BaseCriticalException
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message</param>
        public KernerException(string message) 
            : base(ErrorCodeEnum.CriticalError, message)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message</param>
        public KernerException(String message,Exception ex)
            : base(ErrorCodeEnum.CriticalError, message,ex)
        {
        }
    }
}
