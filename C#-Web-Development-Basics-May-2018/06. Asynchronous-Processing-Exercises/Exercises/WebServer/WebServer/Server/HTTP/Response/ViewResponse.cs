namespace WebServer.Server.HTTP.Response
{
    using Enums;
    using Exceptions;
    using Server.Contracts;

    public class ViewResponse : HttpResponse
    {
        private readonly IView view;

        public ViewResponse(HttpStatusCode statusCode, IView view)
        {
            this.ValidateStatusCode(statusCode);
            this.StatusCode = statusCode;
            this.view = view;
        }

        public override string ToString()
        {
            return $"{base.ToString()}{this.view.View()}";
        }

        private void ValidateStatusCode(HttpStatusCode statusCode)
        {
            var statusCodeNumber = (int) statusCode;
            if (statusCodeNumber >= 300 &&
                statusCodeNumber <= 399)
            {
                throw new InvalidResponseException(
                    "View responses need a status code bellow 300 or above 400 (inclusive).");
            }
        }
    }
}