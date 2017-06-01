using System.IO;

class LineNumbers
{
    static void Main()
    {
        using (var reader = new StreamReader("../../text.txt"))
        {
            using (var writer = new StreamWriter("../../result.txt"))
            {
                var counter = 1;
                var line = string.Empty;

                while ((line = reader.ReadLine()) != null)
                {
                    writer.WriteLine($"{counter}. {line}");
                    ++counter;
                }
            }
        }
    }
}