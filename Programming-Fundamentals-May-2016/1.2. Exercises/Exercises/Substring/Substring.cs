using System;

public class Substring
{
	public static void Main()
	{
		string text = Console.ReadLine();
		int jump = int.Parse(Console.ReadLine());

		const char Search = 'p';
		bool hasMatch = false;

		for (int i = 0; i < text.Length; i++)
		{
            char currentCharacter = text[i];
			if (currentCharacter == Search)
			{
                hasMatch = true;
                int endIndex = i + jump;
                string matchedString = string.Empty;

				if (endIndex < text.Length)
				{
                    matchedString = text.Substring(i, jump + 1);
				}
                else
                {
                    matchedString = text.Substring(i, text.Length - i);
                }

                Console.WriteLine(matchedString);
				i = endIndex;
			}
		}

		if (!hasMatch)
		{
			Console.WriteLine("no");
		}
	}
}
