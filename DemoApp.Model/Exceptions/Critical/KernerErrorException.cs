
using DemoApp.Model.Dal;

namespace DemoApp.Model.Exceptions.Critical
{
    /// <summary>
    /// Application kernel exception
    /// </summary>
    public class KernerErrorException : BaseCriticalException
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message</param>
        public KernerErrorException(string message) 
            : base(ErrorCodeEnum.CriticalError, message)
        {
        }
    }
}
