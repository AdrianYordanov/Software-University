using System;

class ReverseAnArrayOfIntegers
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var array = new int[n];
        var reversedArray = new int[n];

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }

        for (int i = reversedArray.Length - 1; i >= 0; i--)
        {
            reversedArray[i] = array[reversedArray.Length - 1 - i];
        }

        Console.WriteLine(string.Join(" ", reversedArray));
    }
}