using System;
using System.IO;

public class OddLines
{
    private static void Main()
    {
        var reader = new StreamReader("../../text.txt");
        using (reader)
        {
            var lineIndex = 0;
            string line;
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