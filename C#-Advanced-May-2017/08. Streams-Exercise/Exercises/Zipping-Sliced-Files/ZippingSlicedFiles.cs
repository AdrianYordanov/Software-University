using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

public class ZippingSlicedFiles
{
    private static void Main()
    {
        var fileName = "music.mp3";
        var fileDestination = "../..";
        var zips = new List<string> { "part1.gz", "part2.gz", "part3.gz" };
        var zipsDestionation = "../../generated files";
        var parts = int.Parse(Console.ReadLine());
        SliceAndCompress(fileName, fileDestination, parts);
        AssembleAndDecompress(zips, zipsDestionation, "mp3");
    }

    private static void AssembleAndDecompress(List<string> files, string destinationDirectory, string extension)
    {
        using (var result = new FileStream(destinationDirectory + "//result." + extension, FileMode.Create))
        {
            foreach (var file in files)
            {
                using (var currentZip = new FileStream(destinationDirectory + "//" + file, FileMode.Open))
                {
                    using (var currentDecompress = new GZipStream(currentZip, CompressionMode.Decompress, false))
                    {
                        var buffer = new byte[1024];
                        var countBytes = currentDecompress.Read(buffer, 0, buffer.Length);
                        while (countBytes != 0)
                        {
                            result.Write(buffer, 0, countBytes);
                            countBytes = currentDecompress.Read(buffer, 0, buffer.Length);
                        }
                    }
                }
            }
        }
    }

    private static void SliceAndCompress(string sourceFile, string destinationDirectory, int parts)
    {
        var fileSize = 0;
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
                    destinationDirectory + "//generated files//part" + (i + 1) + ".gz",
                    FileMode.Create))
                {
                    using (var compressionFile = new GZipStream(newFile, CompressionMode.Compress, false))
                    {
                        var nestedBuffer = new byte[partSize];
                        file.Read(nestedBuffer, 0, nestedBuffer.Length);
                        compressionFile.Write(nestedBuffer, 0, nestedBuffer.Length);
                    }
                }
            }
        }
    }
}