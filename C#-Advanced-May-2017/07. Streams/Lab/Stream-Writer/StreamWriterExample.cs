﻿using System.IO;

class StreamWriterExample
{
    static void Main()
    {
        using (var reader = new StreamReader("../../StreamWriterExample.cs"))
        {
            using (var writer = new StreamWriter("../../reversed.txt"))
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    for (int i = line.Length - 1; i >= 0; i--)
                    {
                        writer.Write(line[i]);
                    }

                    writer.WriteLine();
                    line = reader.ReadLine();
                }
            }
        }
    }
}