using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class ValidUsernames
{
    static void Main()
    {
        var input = Console.ReadLine();
        var tokens = input.Split(new char[] { ' ', '/', '\\', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
        var regex = new Regex(@"^[a-zA-Z]\w{2,24}$");
        var usernames = new List<string>();
        var biggestSum = 0;
        var biggestLengthIndex = -1;

        foreach (var usernameCandidate in tokens)
        {
            if (regex.IsMatch(usernameCandidate))
            {
                usernames.Add(usernameCandidate);
            }
        }

        for (int i = 0; i < usernames.Count - 1; i++)
        {
            var currentLength = usernames[i].Length + usernames[i + 1].Length;

            if(currentLength > biggestSum)
            {
                biggestSum = currentLength;
                biggestLengthIndex = i;
            }
        }

        Console.WriteLine(usernames[biggestLengthIndex]);
        Console.WriteLine(usernames[biggestLengthIndex + 1]);
    }
}
