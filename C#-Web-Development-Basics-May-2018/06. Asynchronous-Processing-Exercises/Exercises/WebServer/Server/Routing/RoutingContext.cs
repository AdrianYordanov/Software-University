namespace WebServer.Server.Routing
{
    using System.Collections.Generic;
    using Common;
    using Contracts;
    using Handlers.Contracts;

    public class RoutingContext : IRoutingContext
    {
        public RoutingContext(IRequestHandler handler, IEnumerable<string> parameters)
        {
            CoreValidator.ThrowIfNull(handler, nameof(handler));
            CoreValidator.ThrowIfNull(parameters, nameof(parameters));
            this.Handler = handler;
            this.Parameters = parameters;
        }

        public IRequestHandler Handler { get; }

        public IEnumerable<string> Parameters { get; }
    }
}