using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

class HttpServer
{
    private static int PortNumber = 1337;

    static void Main()
    {
        var tcpListener = new TcpListener(IPAddress.Any, PortNumber);
        tcpListener.Start();

        while (true)
        {
            using (NetworkStream stream = tcpListener.AcceptTcpClient().GetStream())
            {
                byte[] request = new byte[4096];
                int readBytes = stream.Read(request, 0, request.Length);
                var response = Encoding.UTF8.GetString(request, 0, readBytes);

                var html = string.Empty;
                var firstLine = response.Split('\n')[0];
                var path = firstLine.Split(new char[] { ' ', '/' }, StringSplitOptions.RemoveEmptyEntries)[1];

                switch (path)
                {
                    case "HTTP":
                        {
                            using (var reader = new StreamReader("../../pages/index.html"))
                            {
                                var line = string.Empty;

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
                                var line = string.Empty;

                                while ((line = reader.ReadLine()) != null)
                                {
                                    html += line + "\n";
                                }
                            }

                            html = String.Format(html, DateTime.Now, Environment.ProcessorCount);

                            break;
                        }
                    default:
                        {
                            using (var reader = new StreamReader("../../pages/error.html"))
                            {
                                var line = string.Empty;

                                while ((line = reader.ReadLine()) != null)
                                {
                                    html += line + "\n";
                                }
                            }

                            break;
                        }
                }

                byte[] htmlBytes = Encoding.UTF8.GetBytes(html);
                stream.Write(htmlBytes, 0, htmlBytes.Length);
            }
        }
    }
}