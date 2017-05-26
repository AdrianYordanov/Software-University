using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class FixEmails
{
    static void Main()
    {
        var input = string.Empty;
        var dictionary = new Dictionary<string, string>();

        while ((input = Console.ReadLine()) != "stop")
        {
            var email = Console.ReadLine();
            var domain = email.Substring(email.Length - 2);

            if (domain.ToLower() == "us" || domain.ToLower() == "uk")
            {
                continue;
            }

            if (dictionary.ContainsKey(input))
            {
                dictionary[input] = email;
            }
            else
            {
                dictionary.Add(input, email);
            }
        }

        foreach (var name in dictionary.Keys)
        {
            Console.WriteLine($"{name} –> {dictionary[name]}");
        }
    }
}