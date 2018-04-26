using System;
using System.IO;
using System.Text;

public class MemoryStreamExample
{
    private static void Main()
    {
        var text = "Two households, both alike in dignity,In fair Verona, where we lay our scene";
        var bytes = Encoding.UTF8.GetBytes(text);
        using (var memoryStream = new MemoryStream(bytes))
        {
            while (true)
            {
                var readByte = memoryStream.ReadByte();
                if (readByte == -1)
                {
                    break;
                }

                Console.WriteLine(Convert.ToString(readByte, 16));
            }
        }
    }
}