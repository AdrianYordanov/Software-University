using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class HttpServer
{
    private static readonly int PortNumber = 1337;

    private static void Main()
    {
        var tcpListener = new TcpListener(IPAddress.Any, PortNumber);
        tcpListener.Start();
        while (true)
        {
            using (var stream = tcpListener.AcceptTcpClient().GetStream())
            {
                var request = new byte[4096];
                var readBytes = stream.Read(request, 0, request.Length);
                var response = Encoding.UTF8.GetString(request, 0, readBytes);
                var html = string.Empty;
                var firstLine = response.Split('\n')[0];
                var path = firstLine.Split(new[] { ' ', '/' }, StringSplitOptions.RemoveEmptyEntries)[1];
                switch (path)
                {
                    case "HTTP":
                        {
                            using (var reader = new StreamReader("../../pages/index.html"))
                            {
                                string line;
                                while ((line = reader.ReadLine()) != null)
                                {
                                    html += line + "\n";
                                }
                            }

                            break;
                        }

                    case "info":
                        {
                            using (var reader = new StreamReader("../../pages/info.html"))
                            {
                                string line;
                                while ((line = reader.ReadLine()) != null)
                                {
                                    html += line + "\n";
                                }
                            }

                            html = string.Format(html, DateTime.Now, Environment.ProcessorCount);
                            break;
                        }

                    default:
                        {
                            using (var reader = new StreamReader("../../pages/error.html"))
                            {
                                string line;
                                while ((line = reader.ReadLine()) != null)
                                {
                                    html += line + "\n";
                                }
                            }

                            break;
                        }
                }

                var htmlBytes = Encoding.UTF8.GetBytes(html);
                stream.Write(htmlBytes, 0, htmlBytes.Length);
            }
        }

        // ReSharper disable once FunctionNeverReturns
    }
}