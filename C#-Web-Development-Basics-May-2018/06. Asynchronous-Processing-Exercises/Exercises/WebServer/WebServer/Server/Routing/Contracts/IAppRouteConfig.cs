﻿namespace WebServer.Server.Routing.Contracts
{
    using System.Collections.Generic;
    using Enums;
    using Handlers;

    public interface IAppRouteConfig
    {
        IReadOnlyDictionary<HttpRequestMethod, IDictionary<string, RequestHandler>> Routes { get; }

        void AddRoute(string route, RequestHandler handler);
    }
}