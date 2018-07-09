namespace WebServer.Server.HTTP.Contracts
{
    using System.Collections.Generic;
    using Enums;

    public interface IHttpRequest
    {
        HttpRequestMethod Method { get; }

        string Url { get; }

        string Path { get; }

        HttpHeaderCollection Headers { get; }

        Dictionary<string, string> FormData { get; }

        Dictionary<string, string> QueryParameters { get; }

        Dictionary<string, string> UrlParameters { get; }

        void AddUrlParameter(string key, string value);
    }
}