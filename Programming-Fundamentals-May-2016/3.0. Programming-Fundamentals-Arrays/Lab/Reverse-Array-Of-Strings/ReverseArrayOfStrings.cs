using System;

class ReverseArrayOfStrings
{
    static void Main()
    {
        string[] array = Console.ReadLine().Split(' ');
        var middle = array.Length / 2;

        for (int i = 0, j = array.Length - 1; i < middle; i++, --j)
        {
            var temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        Console.WriteLine(string.Join(" ", array));
    }
}