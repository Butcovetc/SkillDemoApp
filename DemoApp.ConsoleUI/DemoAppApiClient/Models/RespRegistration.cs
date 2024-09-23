// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace DemoApp.ConsoleUI.Models
{
    /// <summary> The RespRegistration. </summary>
    public partial class RespRegistration
    {
        /// <summary> Initializes a new instance of <see cref="RespRegistration"/>. </summary>
        internal RespRegistration()
        {
        }

        /// <summary> Initializes a new instance of <see cref="RespRegistration"/>. </summary>
        /// <param name="error"></param>
        /// <param name="errorDescription"></param>
        /// <param name="id"></param>
        internal RespRegistration(ErrorCodeEnum? error, string errorDescription, int? id)
        {
            Error = error;
            ErrorDescription = errorDescription;
            Id = id;
        }

        /// <summary> Gets the error. </summary>
        public ErrorCodeEnum? Error { get; }
        /// <summary> Gets the error description. </summary>
        public string ErrorDescription { get; }
        /// <summary> Gets the id. </summary>
        public int? Id { get; }
    }
}
