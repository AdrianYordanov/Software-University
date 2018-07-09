namespace WebServer.Server.Exceptions
{
    using System;

    public class BadRequestException : Exception
    {
        private const string InvalidRequestMessage = "Invalid request line.";

        public BadRequestException(string message)
            : base(message)
        {
        }

        public static void ThrowInvlidRequest()
        {
            throw new BadRequestException(InvalidRequestMessage);
        }
    }
}