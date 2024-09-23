namespace DemoApp.Model.Dal
{
    /// <summary>
    /// Errors result code enum 
    /// </summary>
    public enum ErrorCodeEnum
    {
        /// <summary>
        /// Critical internal error
        /// </summary>
        CriticalError = -1,


        /// <summary>
        /// No result defined
        /// </summary>
        NotSet = 0,

        /// <summary>
        /// Unit of work compleated successfully 
        /// </summary>
        Success = 1,

        /// <summary>
        /// Missing argument exception 
        /// </summary>
        ArgumentMissingException = 10,

        /// <summary>
        /// Wrong argument value exception
        /// </summary>
        WrongArgumentException = 11,


        #region Account units error code's

        /// <summary>
        /// User login not found or not exists
        /// </summary>
        LoginNotFound = 100,

        /// <summary>
        /// Account are not found
        /// </summary>
        AccountAreNotActive = 101,

        /// <summary>
        /// Invalid token exception
        /// </summary>
        InvalidTokenException = 102,

        #endregion


        #region Other area error codes

        OtherAreaErrorCode_1 = 201,

        OtherAreaErrorCode_2 = 202,

        OtherAreaErrorCode_3 = 203,

        OtherAreaErrorCode_4 = 204,

        #endregion
    }
}