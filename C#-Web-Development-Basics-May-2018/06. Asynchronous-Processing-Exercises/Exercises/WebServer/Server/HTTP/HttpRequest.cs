namespace WebServer.Server.HTTP
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Common;
    using Contracts;
    using Enums;
    using Exceptions;

    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            this.Headers = new HttpHeaderCollection();
            this.FormData = new Dictionary<string, string>();
            this.QueryParameters = new Dictionary<string, string>();
            this.UrlParameters = new Dictionary<string, string>();
            this.ParseRequest(requestString);
        }

        public HttpRequestMethod Method { get; private set; }

        public string Url { get; private set; }

        public string Path { get; private set; }

        public HttpHeaderCollection Headers { get; }

        public Dictionary<string, string> FormData { get; }

        public Dictionary<string, string> QueryParameters { get; }

        public Dictionary<string, string> UrlParameters { get; }

        public void AddUrlParameter(string key, string value)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));
            CoreValidator.ThrowIfNullOrEmpty(value, nameof(value));
            this.UrlParameters[key] = value;
        }

        private void ParseRequest(string requestString)
        {
            var requestLines = requestString.Split(new[] {Environment.NewLine}, StringSplitOptions.None);
            if (!requestLines.Any())
            {
                BadRequestException.ThrowInvlidRequest();
            }

            var requestLine = requestLines[0].Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            if (requestLine.Length != 3 ||
                requestLine[2].ToLower() != "http/1.1")
            {
                BadRequestException.ThrowInvlidRequest();
            }

            this.Method = this.ParseMethod(requestLine[0]);
            this.Url = requestLine[1];
            this.Path = this.ParsePath(this.Url);
            this.ParseHeaders(requestLines);
            this.ParseParameters();
            this.ParseFormData(requestLines[requestLines.Length - 1]);
        }

        private HttpRequestMethod ParseMethod(string method)
        {
            if (!Enum.TryParse(method, true, out HttpRequestMethod parseMethod))
            {
                BadRequestException.ThrowInvlidRequest();
            }

            return parseMethod;
        }

        private string ParsePath(string url)
        {
            return url.Split(new[] {'?', '#'}, StringSplitOptions.RemoveEmptyEntries)[0];
        }

        private void ParseHeaders(string[] requestLines)
        {
            var emptyLineIndex = Array.IndexOf(requestLines, string.Empty);
            for (var i = 1; i < emptyLineIndex; i++)
            {
                var headerTokens = requestLines[i].Split(": ");
                if (headerTokens.Length != 2)
                {
                    BadRequestException.ThrowInvlidRequest();
                }

                var headerKey = headerTokens[0];
                var headerValue = headerTokens[1];
                var header = new HttpHeader(headerKey, headerValue);
                this.Headers.Add(header);
            }

            if (!this.Headers.ContainsKey(HttpHeader.Host))
            {
                BadRequestException.ThrowInvlidRequest();
            }
        }

        private void ParseParameters()
        {
            if (!this.Url.Contains("?"))
            {
                return;
            }

            var query = this.Url.Split(new[] {'?'}, StringSplitOptions.RemoveEmptyEntries)[1];
            this.ParseQuery(query, this.QueryParameters);
        }

        private void ParseFormData(string formDataLine)
        {
            if (this.Method == HttpRequestMethod.Post)
            {
                this.ParseQuery(formDataLine, this.FormData);
            }
        }

        private void ParseQuery(string query, IDictionary<string, string> dict)
        {
            if (!query.Contains("="))
            {
                return;
            }

            var queryPairs = query.Split(new[] {'&'}, StringSplitOptions.RemoveEmptyEntries);
            foreach (var queryPair in queryPairs)
            {
                var pairTokens = queryPair.Split(new[] {'='}, StringSplitOptions.RemoveEmptyEntries);
                if (pairTokens.Length != 2)
                {
                    return;
                }

                var queryKey = WebUtility.UrlDecode(pairTokens[0]);
                var queryValue = WebUtility.UrlDecode(pairTokens[1]);
                dict.Add(queryKey, queryValue);
            }
        }
    }
}