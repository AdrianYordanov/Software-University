using System;
using System.Collections.Generic;

public class FixEmails
{
    public static void Main()
    {
        var input = string.Empty;
        var dictionary = new Dictionary<string, string>();
        while ((input = Console.ReadLine()) != "stop")
        {
            var email = Console.ReadLine();
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
            var email = dictionary[name];
            var domain = email.Substring(email.Length - 2);
            if (domain.ToLower() == "us" || domain.ToLower() == "uk")
            {
                dictionary.Remove(name);
                continue;
            }

            Console.WriteLine($"{name} -> {dictionary[name]}");
        }
    }
}