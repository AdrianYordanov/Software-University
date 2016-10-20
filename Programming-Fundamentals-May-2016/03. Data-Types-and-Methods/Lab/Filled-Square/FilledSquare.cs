using System;

class FilledSquare
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        PrintHeaderAndFooterRow(n);
        
        for (int i = 0; i < n - 2; i++)
		{
			 PrintMiddleRow(n);
        }

        PrintHeaderAndFooterRow(n);
    }

    static void PrintHeaderAndFooterRow(int n)
    {
        string line = new string('-', 2 * n);
        Console.WriteLine(line);
    }

    static void PrintMiddleRow(int n)
    {
        string middle = string.Empty;

        for (int i = 0; i < n - 1; ++i)
        {
            middle += "\\/";
        }

        string line = '-' + middle + '-';
        Console.WriteLine(line);
    }
}