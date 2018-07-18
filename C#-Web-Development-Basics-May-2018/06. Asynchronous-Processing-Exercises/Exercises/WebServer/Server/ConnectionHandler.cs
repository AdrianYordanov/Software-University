namespace WebServer.Server
{
    using System;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;
    using Common;
    using Handlers;
    using HTTP;
    using Routing.Contracts;

    public class ConnectionHandler
    {
        private readonly Socket client;
        private readonly IServerRouteConfig serverRouteConfig;

        public ConnectionHandler(Socket client, IServerRouteConfig serverRouteConfig)
        {
            CoreValidator.ThrowIfNull(client, nameof(client));
            CoreValidator.ThrowIfNull(serverRouteConfig, nameof(serverRouteConfig));
            this.client = client;
            this.serverRouteConfig = serverRouteConfig;
        }

        public async Task ProcessRequestAsync()
        {
            var requestAsString = await this.ReadRequest();
            if (requestAsString != null)
            {
                var request = new HttpRequest(requestAsString);
                var context = new HttpContext(request);
                var response = new HttpHandler(this.serverRouteConfig).Handle(context);
                var responseToBytes = new ArraySegment<byte>(Encoding.ASCII.GetBytes(response.ToString()));
                await this.client.SendAsync(responseToBytes, SocketFlags.None);
                Console.WriteLine("-----REQUEST-----");
                Console.WriteLine(requestAsString);
                Console.WriteLine("-----RESPONSE-----");
                Console.WriteLine(response);
                Console.WriteLine();
            }

            this.client.Shutdown(SocketShutdown.Both);
        }

        private async Task<string> ReadRequest()
        {
            var request = new StringBuilder();
            var data = new ArraySegment<byte>(new byte[1024]);
            while (true)
            {
                var numberOfBytes = await this.client.ReceiveAsync(data, SocketFlags.None);
                if (numberOfBytes == 0)
                {
                    break;
                }

                var bytesAsString = Encoding.UTF8.GetString(data.Array, 0, numberOfBytes);
                request.Append(bytesAsString);
                if (numberOfBytes < 1024)
                {
                    break;
                }
            }

            return request.Length == 0 ? null : request.ToString();
        }
    }
}