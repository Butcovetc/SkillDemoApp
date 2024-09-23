using DemoApp.Model.Dal;

namespace DemoApp.Model.Exceptions.Api
{
    /// <summary>
    /// Argument missing exception
    /// </summary>
    internal class ArgumetMissingException : BaseApiException
    {

        /// <summary>
        /// Constuctor
        /// </summary>
        /// <param name="message">Message text</param>
        public ArgumetMissingException(String message) 
            : base(ErrorCodeEnum.ArgumentMissingException,message) { }

        /// <summary>
        /// Throw an a ArgumentMissingException with specified message text
        /// </summary>
        /// <param name="obj">object to check</param>
        /// <exception cref="ArgumetMissingException">Exception message</exception>
        public static void ThrowIfNullOrEmpty(String? obj)
            => ThrowIfNullOrEmpty(obj, String.Empty);

        /// <summary>
        /// Throw an a ArgumentMissingException with specified message text
        /// </summary>
        /// <param name="obj">object to check</param>
        /// <param name="message">Exception mesage</param>
        /// <exception cref="ArgumetMissingException">Exception message</exception>
        public static void ThrowIfNullOrEmpty(String? obj,String message)
        {
            if (obj == null)
                throw new ArgumetMissingException(message);
        }

        /// <summary>
        /// Throw an a ArgumentMissingException with specified message text
        /// </summary>
        /// <param name="obj">object to check</param>
        /// <exception cref="ArgumetMissingException">Exception message</exception>
        public static void ThrowIfNull(Object? obj)
            => TrowIfNull(obj,String.Empty);
        

        /// <summary>
        /// Throw an a ArgumentMissingException with specified message text
        /// </summary>
        /// <param name="obj">object to check</param>
        /// <param name="message">Exception mesage</param>
        /// <exception cref="ArgumetMissingException">Exception message</exception>
        public static void TrowIfNull(Object obj, String message)
        {
            if (obj == null)
                throw new ArgumetMissingException(message);
        }
        
    }
}
