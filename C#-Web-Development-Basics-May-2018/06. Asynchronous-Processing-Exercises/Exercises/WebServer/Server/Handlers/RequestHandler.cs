namespace WebServer.Server.Handlers
{
    using System;
    using Common;
    using Contracts;
    using HTTP;
    using HTTP.Contracts;

    public class RequestHandler : IRequestHandler
    {
        private readonly Func<IHttpRequest, IHttpResponse> handlingFunc;

        public RequestHandler(Func<IHttpRequest, IHttpResponse> handlingFunc)
        {
            CoreValidator.ThrowIfNull(handlingFunc, nameof(handlingFunc));
            this.handlingFunc = handlingFunc;
        }

        public IHttpResponse Handle(IHttpContext context)
        {
            var response = this.handlingFunc(context.Request);
            response.Headers.Add(new HttpHeader("Content-Type", "text/html"));
            return response;
        }
    }
}