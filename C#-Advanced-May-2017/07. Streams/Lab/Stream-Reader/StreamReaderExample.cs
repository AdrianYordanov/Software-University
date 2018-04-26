using System;
using System.IO;

public class StreamReaderExample
{
    private static void Main()
    {
        using (var reader = new StreamReader("../../somefile.txt"))
        {
            var lineNumber = 0;
            var line = reader.ReadLine();
            while (line != null)
            {
                lineNumber++;
                Console.WriteLine("Line {0}: {1}", lineNumber, line);
                line = reader.ReadLine();
            }
        }
    }
}