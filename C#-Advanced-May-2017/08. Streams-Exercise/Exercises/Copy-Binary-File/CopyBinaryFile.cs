using System.IO;

public class CopyBinaryFile
{
    private static void Main()
    {
        using (var file = new FileStream("../../logo.png", FileMode.Open))
        {
            using (var createFile = new FileStream("../../result.png", FileMode.Create))
            {
                var buffer = new byte[4096];
                var countBytes = file.Read(buffer, 0, buffer.Length);
                while (countBytes != 0)
                {
                    createFile.Write(buffer, 0, countBytes);
                    countBytes = file.Read(buffer, 0, buffer.Length);
                }
            }
        }
    }
}