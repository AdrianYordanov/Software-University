using System;
using System.IO;
using System.Threading.Tasks;

public class StartUp
{
    private static void Main()
    {
        var sourceFile = Console.ReadLine();
        var destinationPath = Console.ReadLine();
        var parts = int.Parse(Console.ReadLine());
        SliceAssync(sourceFile, destinationPath, parts);
        Console.WriteLine("Anything else?");
        while (true)
        {
            Console.ReadLine();
        }

        // ReSharper disable once FunctionNeverReturns
    }

    private static void SliceAssync(string sourceFile, string destinationPath, int parts)
    {
        Task.Run(() => Slice(sourceFile, destinationPath, parts));
    }

    private static void Slice(string sourceFie, string destinationPath, int parts)
    {
        if (!Directory.Exists(destinationPath))
        {
            Directory.CreateDirectory($"{destinationPath}");
        }

        using (var source = new FileStream(sourceFie, FileMode.Open))
        {
            var fileInfo = new FileInfo(sourceFie);
            var bufferLengthPart = (source.Length / parts) + 1L;
            var currentByte = 0L;
            for (var currentPart = 1; currentPart <= parts; currentPart++)
            {
                var outputFilePath = $"{destinationPath}/Part-{currentPart}{fileInfo.Extension}";
                using (var destination = new FileStream(outputFilePath, FileMode.Create))
                {
                    var buffer = new byte[bufferLengthPart];
                    while (currentByte <= (bufferLengthPart * currentPart))
                    {
                        var readBytesCount = source.Read(buffer, 0, buffer.Length);
                        if (readBytesCount == 0)
                        {
                            break;
                        }

                        destination.Write(buffer, 0, buffer.Length);
                        currentByte += readBytesCount;
                    }
                }
            }
        }

        Console.WriteLine("Slice complete.");
    }
}