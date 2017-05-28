using System;
using System.Collections.Generic;
using System.Linq;

class UserLogs
{
    static void Main()
    {
        var input = string.Empty;
        var users = new SortedDictionary<string, Dictionary<string, int>>();

        while ((input = Console.ReadLine()) != "end")
        {
            var tokens = input.Split(' ');
            var ip = tokens[0].Split('=')[1];
            var user = tokens[2].Split('=')[1];

            if (users.ContainsKey(user))
            {
                if (users[user].ContainsKey(ip))
                {
                    users[user][ip]++;
                }
                else
                {
                    users[user].Add(ip, 1);
                }
            }
            else
            {
                var userIps = new Dictionary<string, int>();
                userIps.Add(ip, 1);
                users.Add(user, userIps);
            }
        }

        foreach (var name in users.Keys)
        {
            Console.WriteLine(name + ":");
            var ips = users[name];

            Console.WriteLine(string.Join(", ", ips.Select(x => x.Key + " => " + x.Value).ToArray()) + ".");
        }
    }
}