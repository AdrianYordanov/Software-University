using System;
using System.Collections.Generic;

public class Phonebook
{
    public static void Main()
    {
        var phonebook = new Dictionary<string, string>();
        var input = string.Empty;
        while ((input = Console.ReadLine()) != "search")
        {
            var tokens = input.Split('-');
            var name = tokens[0];
            var number = tokens[1];
            if (phonebook.ContainsKey(name))
            {
                phonebook[name] = number;
            }
            else
            {
                phonebook.Add(name, number);
            }
        }

        while ((input = Console.ReadLine()) != "stop")
        {
            Console.WriteLine(phonebook.ContainsKey(input) ? $"{input} -> {phonebook[input]}" : $"Contact {input} does not exist.");
        }
    }
}