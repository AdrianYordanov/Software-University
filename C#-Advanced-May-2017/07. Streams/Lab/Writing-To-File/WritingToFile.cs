using System.IO;
using System.Text;

public class WritingToFile
{
    private static void Main()
    {
        var text = "Кирилица";
        var fileStream = new FileStream("../../log.txt", FileMode.Create);
        try
        {
            var bytes = Encoding.UTF8.GetBytes(text);
            fileStream.Write(bytes, 0, bytes.Length);
        }
        finally
        {
            fileStream.Close();
        }
    }
}