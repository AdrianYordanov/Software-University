using System;
using System.IO;

class OddLines
{
    static void Main()
    {
        var reader = new StreamReader("../../text.txt");

        using (reader)
        {
            var lineIndex = 0;
            var line = string.Empty;

            while ((line = reader.ReadLine()) != null)
            {
                if (lineIndex % 2 != 0)
                {
                    Console.WriteLine(line);
                }

                ++lineIndex;
            }
        }
    }
}