using System;
using System.Text;
using System.Net;

public class StartUp
{
    private static void Main()
    {
        var urlInput = Console.ReadLine();
        var decodedUrl = WebUtility.UrlDecode(urlInput);
        try
        {
            var parsedUrl = new Uri(decodedUrl);
            if (string.IsNullOrWhiteSpace(parsedUrl.Scheme) ||
                string.IsNullOrWhiteSpace(parsedUrl.Host) ||
                string.IsNullOrWhiteSpace(parsedUrl.LocalPath))
            {
                throw new ArgumentException("Invalid URL");
            }

            var builder = new StringBuilder();
            builder
                .AppendLine($"Protocol: {parsedUrl.Scheme}")
                .AppendLine($"Host: {parsedUrl.Host}")
                .AppendLine($"Port: {parsedUrl.Port}")
                .AppendLine($"Path: {parsedUrl.LocalPath}");
            if (!string.IsNullOrWhiteSpace(parsedUrl.Query))
            {
                builder.AppendLine($"Query: {parsedUrl.Query.Substring(1)}");
            }

            if (!string.IsNullOrWhiteSpace(parsedUrl.Fragment))
            {
                builder.AppendLine($"Fragment: {parsedUrl.Fragment.Substring(1)}");
            }

            Console.WriteLine(builder.ToString().Trim());
        }
        catch (Exception ae)
        {
            Console.WriteLine(ae.Message);
        }
    }
}