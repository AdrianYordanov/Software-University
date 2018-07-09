﻿namespace WebServer.Server.Routing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Enums;
    using Handlers;
    using HTTP.Contracts;

    public class AppRouteConfig : IAppRouteConfig
    {
        private readonly Dictionary<HttpRequestMethod, IDictionary<string, RequestHandler>> routes;

        public AppRouteConfig()
        {
            this.routes = new Dictionary<HttpRequestMethod, IDictionary<string, RequestHandler>>();
            var availableMethods = Enum.GetValues(typeof(HttpRequestMethod)).Cast<HttpRequestMethod>();
            foreach (var method in availableMethods)
            {
                this.routes[method] = new Dictionary<string, RequestHandler>();
            }
        }

        public IReadOnlyDictionary<HttpRequestMethod, IDictionary<string, RequestHandler>> Routes => this.routes;

        public void Get(string route, Func<IHttpRequest, IHttpResponse> func)
        {
            this.AddRoute(route, HttpRequestMethod.Get, new RequestHandler(func));
        }

        public void Post(string route, Func<IHttpRequest, IHttpResponse> func)
        {
            this.AddRoute(route, HttpRequestMethod.Post, new RequestHandler(func));
        }

        private void AddRoute(string route, HttpRequestMethod method, RequestHandler handler)
        {
            this.routes[method].Add(route, handler);
        }
    }
}