using System;

class ParseUrl
{
    static void Main()
    {
        var url = Console.ReadLine();
        var mainTokens = url.Split(new[] { "://" }, StringSplitOptions.RemoveEmptyEntries);

        if (mainTokens.Length != 2 || mainTokens[1].IndexOf("/") < 0)
        {
            Console.WriteLine("Invalid URL");
        }
        else
        {
            var resourceIndex = mainTokens[1].IndexOf("/");
            var protocol = mainTokens[0];
            var server = mainTokens[1].Substring(0, resourceIndex);
            var resource = mainTokens[1].Substring(resourceIndex + 1);

            Console.WriteLine($"Protocol = {protocol}");
            Console.WriteLine($"Server = {server}");
            Console.WriteLine($"Resources = {resource}");
        }
    }
}