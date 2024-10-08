﻿using DemoApp.Model.Dal;

namespace DemoApp.Model.Exceptions
{
    /// <summary>
    /// Base class for all exceptions
    /// </summary>
    internal class BaseApiException : DemoAppException
    {

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="errorCode">Error code</param>
        /// <param name="message">Message text</param>
        public BaseApiException(ErrorCodeEnum errorCode, string message) : base(errorCode, message)
        {
        }
    }
}
