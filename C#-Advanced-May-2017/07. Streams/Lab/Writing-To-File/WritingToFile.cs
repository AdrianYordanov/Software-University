using System.IO;
using System.Text;

class WritingToFile
{
    static void Main()
    {
        string text = "Кирилица";
        var fileStream = new FileStream("../../log.txt", FileMode.Create);

        try
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            fileStream.Write(bytes, 2, bytes.Length - 2);
        }
        finally
        {
            fileStream.Close();
        }
    }
}