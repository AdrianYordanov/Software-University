namespace WebServer.Server.HTTP.Response
{
    using System.Text;
    using Contracts;
    using Enums;

    public abstract class HttpResponse : IHttpResponse
    {
        protected HttpResponse()
        {
            this.Headers = new HttpHeaderCollection();
        }

        public HttpStatusCode StatusCode { get; protected set; }

        public IHttpHeaderCollection Headers { get; }

        private string StatusCodeMessage => this.StatusCode.ToString();

        public override string ToString()
        {
            var statusCodeNumber = (int) this.StatusCode;
            var response = new StringBuilder();
            response.AppendLine($"HTTP/1.1 {statusCodeNumber} {this.StatusCodeMessage}");
            response.AppendLine(this.Headers.ToString());
            response.AppendLine();
            return response.ToString();
        }
    }
}