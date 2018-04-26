using System;
using System.Collections.Generic;
using System.IO;

public class SliciningFile
{
    private static void Assemble(List<string> files, string destinationDirectory)
    {
        var extension = files[0].Split('.')[1];
        using (var result = new FileStream(destinationDirectory + "//result." + extension, FileMode.Create))
        {
            foreach (var file in files)
            {
                using (var currentFile = new FileStream(destinationDirectory + "//" + file, FileMode.Open))
                {
                    var buffer = new byte[1024];
                    var countBytes = currentFile.Read(buffer, 0, buffer.Length);
                    while (countBytes != 0)
                    {
                        result.Write(buffer, 0, countBytes);
                        countBytes = currentFile.Read(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }

    private static void Main()
    {
        var fileName = "music.mp3";
        var fileDestination = "../..";
        var files = new List<string> { "part1.mp3", "part2.mp3", "part3.mp3" };
        var filesDestionation = "../../generated files";
        var parts = int.Parse(Console.ReadLine());
        Slice(fileName, fileDestination, parts);
        Assemble(files, filesDestionation);
    }

    private static void Slice(string sourceFile, string destinationDirectory, int parts)
    {
        var fileSize = 0;
        var extension = sourceFile.Split('.')[1];
        using (var file = new FileStream(destinationDirectory + "//" + sourceFile, FileMode.Open))
        {
            var buffer = new byte[1024];
            var countBytes = file.Read(buffer, 0, buffer.Length);
            while (countBytes != 0)
            {
                fileSize += countBytes;
                countBytes = file.Read(buffer, 0, buffer.Length);
            }

            file.Seek(0, SeekOrigin.Begin);
            var partSize = fileSize / parts;
            for (var i = 0; i < parts; i++)
            {
                using (var newFile = new FileStream(
                    destinationDirectory + "//generated files//part" + (i + 1) + "." + extension,
                    FileMode.Create))
                {
                    var nestedBuffer = new byte[partSize];
                    file.Read(nestedBuffer, 0, nestedBuffer.Length);
                    newFile.Write(nestedBuffer, 0, nestedBuffer.Length);
                }
            }
        }
    }
}