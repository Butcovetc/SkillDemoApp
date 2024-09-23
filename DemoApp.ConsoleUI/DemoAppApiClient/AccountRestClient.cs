// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using DemoApp.ConsoleUI.Models;

namespace DemoApp.ConsoleUI
{
    internal partial class AccountRestClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> Initializes a new instance of AccountRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/>, <paramref name="pipeline"/> or <paramref name="endpoint"/> is null. </exception>
        public AccountRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint)
        {
            ClientDiagnostics = clientDiagnostics ?? throw new ArgumentNullException(nameof(clientDiagnostics));
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? throw new ArgumentNullException(nameof(endpoint));
        }

        internal HttpMessage CreateLoginRequest(ReqLogin body)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/demoSubArea/Account/Login", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            if (body != null)
            {
                request.Headers.Add("Content-Type", "application/json");
                var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(body);
                request.Content = content;
            }
            return message;
        }

        /// <param name="body"> The <see cref="ReqLogin"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<RespLogin>> LoginAsync(ReqLogin body = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateLoginRequest(body);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        RespLogin value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = RespLogin.DeserializeRespLogin(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <param name="body"> The <see cref="ReqLogin"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<RespLogin> Login(ReqLogin body = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateLoginRequest(body);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        RespLogin value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = RespLogin.DeserializeRespLogin(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetAllAccountsRequest(RequestTokenBased body)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/demoSubArea/Account/List", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            if (body != null)
            {
                request.Headers.Add("Content-Type", "application/json");
                var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(body);
                request.Content = content;
            }
            return message;
        }

        /// <param name="body"> The <see cref="RequestTokenBased"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<AccountItemResponseList>> GetAllAccountsAsync(RequestTokenBased body = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateGetAllAccountsRequest(body);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        AccountItemResponseList value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = AccountItemResponseList.DeserializeAccountItemResponseList(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <param name="body"> The <see cref="RequestTokenBased"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<AccountItemResponseList> GetAllAccounts(RequestTokenBased body = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateGetAllAccountsRequest(body);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        AccountItemResponseList value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = AccountItemResponseList.DeserializeAccountItemResponseList(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
