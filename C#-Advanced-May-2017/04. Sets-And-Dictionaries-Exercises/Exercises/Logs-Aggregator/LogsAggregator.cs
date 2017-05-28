using System;
using System.Collections.Generic;
using System.Linq;

class LogsAggregator
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var users = new SortedDictionary<string, SortedDictionary<string, int>>();

        for (int i = 0; i < n; i++)
        {
            var tokens = Console.ReadLine().Split(' ');
            var user = tokens[1];
            var ip = tokens[0];
            var duration = int.Parse(tokens[2]);

            if (users.ContainsKey(user))
            {
                if (users[user].ContainsKey(ip))
                {
                    users[user][ip] += duration;
                }
                else
                {
                    users[user].Add(ip, duration);
                }
            }
            else
            {
                var ips = new SortedDictionary<string, int>();
                ips.Add(ip, duration);
                users.Add(user, ips);
            }
        }

        foreach (var user in users.Keys)
        {
            Console.WriteLine($"{user}: {users[user].Values.Sum()} [{string.Join(", ", users[user].Keys.ToArray())}]");
        }
    }
}