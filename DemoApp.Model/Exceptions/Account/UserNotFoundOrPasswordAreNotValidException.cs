using DemoApp.Model.Dal;

namespace DemoApp.Model.Exceptions.Api
{
    /// <summary>
    /// Argument missing exception
    /// </summary>
    internal class UserNotFoundOrPasswordAreNotValidException : BaseApiException
    {
        /// <summary>
        /// Constuctor
        /// </summary>
        public UserNotFoundOrPasswordAreNotValidException() 
            : base(ErrorCodeEnum.LoginNotFound, "User not found or password are incorect!") { }
    }
}
