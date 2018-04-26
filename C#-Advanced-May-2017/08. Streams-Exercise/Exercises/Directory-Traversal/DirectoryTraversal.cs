using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class DirectoryTraversal
{
    private static void Main()
    {
        var folderPath = Console.ReadLine();

        // folderPath = "../../obj/Debug/";
        var foundFiles = Directory.GetFiles(folderPath);
        var extensions = new Dictionary<string, Dictionary<string, double>>();
        foreach (var file in foundFiles)
        {
            var fileName = Path.GetFileName(file);
            var extension = fileName.Substring(fileName.LastIndexOf('.'));
            if (extensions.ContainsKey(extension))
            {
                extensions[extension][fileName] = new FileInfo(file).Length / (double)1024;
            }
            else
            {
                var dictionary = new Dictionary<string, double>();
                dictionary.Add(fileName, new FileInfo(file).Length / (double)1024);
                extensions.Add(extension, dictionary);
            }
        }

        var orderedExtensions = extensions.OrderByDescending(pair => pair.Value.Count).ThenBy(pair => pair.Key);
        using (var result =
            new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/report.txt"))
        {
            foreach (var pair in orderedExtensions)
            {
                result.WriteLine(pair.Key);
                foreach (var nestedPair in pair.Value.OrderBy(x => x.Value))
                {
                    result.WriteLine($"--{nestedPair.Key} - {nestedPair.Value}kb");
                }
            }
        }
    }
}