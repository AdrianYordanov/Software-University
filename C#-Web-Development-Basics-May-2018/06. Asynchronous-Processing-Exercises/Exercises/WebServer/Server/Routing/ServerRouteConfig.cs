namespace WebServer.Server.Routing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using Contracts;
    using Enums;

    public class ServerRouteConfig : IServerRouteConfig
    {
        public ServerRouteConfig(IAppRouteConfig appRoutConfig)
        {
            this.Routes = new Dictionary<HttpRequestMethod, IDictionary<string, IRoutingContext>>();
            var availableMethods = Enum.GetValues(typeof(HttpRequestMethod)).Cast<HttpRequestMethod>();
            foreach (var method in availableMethods)
            {
                this.Routes[method] = new Dictionary<string, IRoutingContext>();
            }

            this.InitializeRouteConfig(appRoutConfig);
        }

        public IDictionary<HttpRequestMethod, IDictionary<string, IRoutingContext>> Routes { get; }

        private void InitializeRouteConfig(IAppRouteConfig appRoutConfig)
        {
            foreach (var registeredRoute in appRoutConfig.Routes)
            {
                var requestMethod = registeredRoute.Key;
                var routeWithHandlers = registeredRoute.Value;
                foreach (var routeWithHandler in routeWithHandlers)
                {
                    var route = routeWithHandler.Key;
                    var handler = routeWithHandler.Value;
                    var parameters = new List<string>();
                    var parsedRouteRegex = this.ParseRoute(route, parameters);
                    var routingContext = new RoutingContext(handler, parameters);
                    this.Routes[requestMethod].Add(parsedRouteRegex, routingContext);
                }
            }
        }

        private string ParseRoute(string route, List<string> parameters)
        {
            var result = new StringBuilder();
            result.Append("^/");
            if (route == "/")
            {
                return result.Append("$").ToString();
            }

            var tokens = route.Split(new[] {'/'}, StringSplitOptions.RemoveEmptyEntries);
            this.ParseTokens(tokens, parameters, result);
            return result.ToString();
        }

        private void ParseTokens(string[] tokens, List<string> parameters, StringBuilder result)
        {
            for (var i = 0; i < tokens.Length; i++)
            {
                var endCharacter = tokens.Length - 1 == i ? "$" : "/";
                var currentToken = tokens[i];
                if (!currentToken.StartsWith("{") &&
                    !currentToken.EndsWith("}"))
                {
                    result.Append($"{currentToken}{endCharacter}");
                    continue;
                }

                var parameterRegex = new Regex("<\\w+>");
                var parameterMatch = parameterRegex.Match(currentToken);
                if (!parameterMatch.Success)
                {
                    throw new InvalidOperationException($"Route parameter in '{currentToken}' is not valid.");
                }

                var match = parameterMatch.Value;
                var parameter = match.Substring(1, match.Length - 2);
                var tokenWithoutCurlyBrackets = currentToken.Substring(1, currentToken.Length - 2);
                parameters.Add(parameter);
                result.Append($"{tokenWithoutCurlyBrackets}{endCharacter}");
            }
        }
    }
}