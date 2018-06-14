namespace Simple_Web_Server
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;

    public class StartUp
    {
        private static void Main()
        {
            var address = IPAddress.Parse("127.0.0.1");
            var port = 130;
            var listener = new TcpListener(address, port);
            listener.Start();
            Console.WriteLine("Server started.");
            Console.WriteLine($"Listening to TCP clients at {address}:{port}");
            ConnectWithTcpListener(listener).Wait();
        }

        private static async Task ConnectWithTcpListener(TcpListener listener)
        {
            while (true)
            {
                Console.WriteLine("Waiting for client...");
                var client = await listener.AcceptTcpClientAsync();
                Console.WriteLine("Client connected.");
                var buffer = new byte[1024];
                client.GetStream().Read(buffer, 0, buffer.Length);
                var message = Encoding.UTF8.GetString(buffer);
                Console.WriteLine(message);
                buffer = Encoding.UTF8.GetBytes("Hello from server!");
                client.GetStream().Write(buffer, 0, buffer.Length);
                Console.WriteLine("Closing connection.");
                client.GetStream().Dispose();
            }

            // ReSharper disable once FunctionNeverReturns
        }
    }
}