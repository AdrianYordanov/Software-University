using System;
using System.Net;

public class StartUp
{
    private static void Main()
    {
        var urlInput = Console.ReadLine();
        var decodedUrl = WebUtility.UrlDecode(urlInput);
        Console.WriteLine(decodedUrl);
    }
}