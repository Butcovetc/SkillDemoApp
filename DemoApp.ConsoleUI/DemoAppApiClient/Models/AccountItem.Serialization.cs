// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure;

namespace DemoApp.ConsoleUI.Models
{
    public partial class AccountItem
    {
        internal static AccountItem DeserializeAccountItem(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int? id = default;
            string login = default;
            string email = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    id = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("login"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        login = null;
                        continue;
                    }
                    login = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("email"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        email = null;
                        continue;
                    }
                    email = property.Value.GetString();
                    continue;
                }
            }
            return new AccountItem(id, login, email);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static AccountItem FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeAccountItem(document.RootElement);
        }
    }
}
