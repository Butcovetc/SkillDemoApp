// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace DemoApp.ConsoleUI.Models
{
    /// <summary> The RespLogin. </summary>
    public partial class RespLogin
    {
        /// <summary> Initializes a new instance of <see cref="RespLogin"/>. </summary>
        internal RespLogin()
        {
        }

        /// <summary> Initializes a new instance of <see cref="RespLogin"/>. </summary>
        /// <param name="error"></param>
        /// <param name="errorDescription"></param>
        /// <param name="login"></param>
        /// <param name="email"></param>
        /// <param name="token"></param>
        internal RespLogin(ErrorCodeEnum? error, string errorDescription, string login, string email, string token)
        {
            Error = error;
            ErrorDescription = errorDescription;
            Login = login;
            Email = email;
            Token = token;
        }

        /// <summary> Gets the error. </summary>
        public ErrorCodeEnum? Error { get; }
        /// <summary> Gets the error description. </summary>
        public string ErrorDescription { get; }
        /// <summary> Gets the login. </summary>
        public string Login { get; }
        /// <summary> Gets the email. </summary>
        public string Email { get; }
        /// <summary> Gets the token. </summary>
        public string Token { get; }
    }
}
