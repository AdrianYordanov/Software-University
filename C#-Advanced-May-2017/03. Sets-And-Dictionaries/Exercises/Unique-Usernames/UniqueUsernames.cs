using System;
using System.Collections.Generic;

class UniqueUsernames
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var users = new HashSet<string>();

        for (int i = 0; i < n; i++)
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