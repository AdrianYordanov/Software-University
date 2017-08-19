using System;

public class OutputHandler : IOutputHandler
{
    public void PrintLine(string line)
    {
        Console.WriteLine(line);
    }
}