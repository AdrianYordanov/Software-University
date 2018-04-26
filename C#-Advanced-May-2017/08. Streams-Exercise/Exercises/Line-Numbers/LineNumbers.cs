using System.IO;

public class LineNumbers
{
    private static void Main()
    {
        using (var reader = new StreamReader("../../text.txt"))
        {
            using (var writer = new StreamWriter("../../result.txt"))
            {
                var counter = 1;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    writer.WriteLine($"{counter}. {line}");
                    ++counter;
                }
            }
        }
    }
}