﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.Relay
{
    using System;
    using System.Reflection;
    using System.Runtime.InteropServices;

    static class HybridConnectionConstants
    {
        public const string HybridConnectionRequestUri = "/$hc";
        public const string SecureWebSocketScheme = "wss";
        public const int MaxUnrecognizedJson = 1024;
        internal const bool DefaultUseBuiltInClientWebSocket = false;

        // Names of query string options
        public const string QueryStringKeyPrefix = "sb-hc-";
        public const string Action = QueryStringKeyPrefix + "action"; // sb-hc-action
        public const string Id = QueryStringKeyPrefix + "id"; // sb-hc-id
        public const string StatusCode = QueryStringKeyPrefix + "statusCode"; // sb-hc-statusCode
        public const string StatusDescription = QueryStringKeyPrefix + "statusDescription"; // sb-hc-statusDescription
        public const string Token = QueryStringKeyPrefix + "token"; // sb-hc-token
        public const string SasKeyName = QueryStringKeyPrefix + "sas-key-name"; // sb-hc-sas-key-name
        public const string SasKey = QueryStringKeyPrefix + "sas-key"; // sb-hc-sas-key

        public static readonly TimeSpan KeepAliveInterval = TimeSpan.FromMinutes(3.5);

        // e.g. "azure-relay-dotnet/2.0.1.0 (Microsoft Windows NT 10.0.18363.0; .NET Core 4.6.28008.01)"
        public static readonly string ClientAgent = $"azure-relay-dotnet/{GetFileVersion()} ({Environment.OSVersion}; {PlatformHelpers.GetRuntimeFramework()})";

        static string GetFileVersion()
        {
            var a = Assembly.GetExecutingAssembly();
            var attribute = a.GetCustomAttribute<AssemblyFileVersionAttribute>();
            return attribute.Version;
        }

        public static class Actions
        {
            public const string Listen = "listen";
            public const string Accept = "accept";
            public const string Connect = "connect";
            public const string Request = "request";
        }

        public static class Headers
        {
            // ClientWebSocket on .NET Framework doesn't allow us to set User-Agent header because it's a property
            // on HttpWebRequest and cannot be added via the generic Add(string, string) mechanism.
            public const string RelayUserAgent = "Relay-User-Agent";
            public const string SecWebSocketExtensions = "Sec-WebSocket-Extensions";
            public const string SecWebSocketKey = "Sec-WebSocket-Key";
            public const string SecWebSocketProtocol = "Sec-WebSocket-Protocol";
            public const string SecWebSocketVersion = "Sec-WebSocket-Version";
        }
    }
}
