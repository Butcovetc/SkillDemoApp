﻿namespace DemoApp.Model.Dal.Response.Base
{
    /// <summary>
    /// Base object to all responses  
    /// </summary>
    public class ResponseBase
    {
        /// <summary>
        /// Unit result error code 
        /// </summary>
        public ErrorCodeEnum Error { get; set; } = ErrorCodeEnum.NotSet;

        /// <summary>
        /// Array of error's description
        /// </summary>
        public String ErrorDescription { get; set; } = String.Empty;
    }
}
