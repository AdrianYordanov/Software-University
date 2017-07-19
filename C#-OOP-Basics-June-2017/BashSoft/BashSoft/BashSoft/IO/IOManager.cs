namespace BashSoft.IO
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Exceptions;
    using Static_data;

    // ReSharper disable once InconsistentNaming
    public class IOManager
    {
        public void TraverseDirectory(int depth)
        {
            OutputWriter.WriteEmptyLine();
            var initialIndentation = SessionsData.CurrentPath.Split('\\').Length;
            var subFolders = new Queue<string>();
            subFolders.Enqueue(SessionsData.CurrentPath);

            while (subFolders.Count != 0)
            {
                var currentPath = subFolders.Dequeue();
                var indentation = currentPath.Split('\\').Length - initialIndentation;

                if (depth - indentation < 0)
                {
                    break;
                }

                OutputWriter.WriteMessageOnNewLine($"{new string('-', indentation)}{currentPath}");

                try
                {
                    foreach (var file in Directory.GetFiles(currentPath))
                    {
                        var indexOfLastSlash = file.LastIndexOf(@"\", StringComparison.Ordinal);
                        var filename = file.Substring(indexOfLastSlash);
                        OutputWriter.WriteMessageOnNewLine(new string('-', indexOfLastSlash) + filename);
                    }

                    var subDirectories = Directory.GetDirectories(currentPath);
                    foreach (var subDir in subDirectories)
                    {
                        subFolders.Enqueue(subDir);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    OutputWriter.DisplayException(ExceptionMessages.UnauthorizedAccessExceptionMessage);
                }
            }
        }

        public void CreateDirectoryInCurrentFolder(string name)
        {
            var path = this.GetCurrentDirectoryPath() + "\\" + name;

            try
            {
                Directory.CreateDirectory(path);
            }
            catch (ArgumentException)
            {
                throw new InvalidFileNameException();
            }
        }

        public void ChangeCurrentDirectoryRelative(string relativePath)
        {
            if (relativePath == "..")
            {
                try
                {
                    var currentPath = SessionsData.CurrentPath;
                    var indexOfLastSlash = currentPath.LastIndexOf(@"\", StringComparison.Ordinal);
                    var newPath = currentPath.Substring(0, indexOfLastSlash);
                    SessionsData.CurrentPath = newPath;
                }
                catch (ArgumentOutOfRangeException)
                {
                    // ReSharper disable once NotResolvedInText
                    throw new ArgumentOutOfRangeException("indexOfLastSlash", ExceptionMessages.UnableToGoHigherInPartitionHierarchy);
                }
            }
            else
            {
                var currentPath = SessionsData.CurrentPath;
                currentPath += @"\" + relativePath;
                this.ChangeCurrentDirectoryAbsolute(currentPath);
            }
        }

        public void ChangeCurrentDirectoryAbsolute(string absolutePath)
        {
            if (!Directory.Exists(absolutePath))
            {
                throw new InvalidPathException();
            }

            SessionsData.CurrentPath = absolutePath;
        }

        private string GetCurrentDirectoryPath()
        {
            return SessionsData.CurrentPath;
        }
    }
}