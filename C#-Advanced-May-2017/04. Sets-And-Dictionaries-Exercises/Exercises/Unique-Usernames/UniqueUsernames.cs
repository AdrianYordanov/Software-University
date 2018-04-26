using System;
using System.Collections.Generic;

public class UniqueUsernames
{
    private static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var users = new HashSet<string>();
        for (var i = 0; i < n; i++)
        {
            var username = Console.ReadLine();
            users.Add(username);
        }

        foreach (var username in users)
        {
            Console.WriteLine(username);
        }
    }
}