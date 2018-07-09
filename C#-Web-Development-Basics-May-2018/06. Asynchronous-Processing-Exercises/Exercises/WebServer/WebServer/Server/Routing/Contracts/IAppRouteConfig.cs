namespace WebServer.Server.Routing.Contracts
{
    using System;
    using System.Collections.Generic;
    using Enums;
    using Handlers;
    using HTTP.Contracts;

    public interface IAppRouteConfig
    {
        IReadOnlyDictionary<HttpRequestMethod, IDictionary<string, RequestHandler>> Routes { get; }

        void Get(string route, Func<IHttpRequest, IHttpResponse> func);

        void Post(string route, Func<IHttpRequest, IHttpResponse> func);
    }
}