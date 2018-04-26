using System;
using System.Diagnostics;
using System.IO;
using System.Text;

public class BufferedWriter
{
    private static void Main()
    {
        var watch = new Stopwatch();
        watch.Start();
        var fs = new FileStream("text.txt", FileMode.Create);
        using (fs)
        {
            for (var i = 0; i < 100000; i++)
            {
                var buffer = Encoding.ASCII.GetBytes(i.ToString());
                fs.Read(buffer, 0, buffer.Length);
            }
        }

        Console.WriteLine("Done: {0}", watch.Elapsed);
    }
}