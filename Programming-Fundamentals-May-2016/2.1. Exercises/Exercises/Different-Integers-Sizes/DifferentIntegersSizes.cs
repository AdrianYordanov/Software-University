using System;

class DifferentIntegersSizes
{
    static void Main()
    {
        string input = Console.ReadLine();
        object test;
        long anotherTest = 0;

        if (long.TryParse(input, out anotherTest))
        {
            Console.WriteLine("{0} can fit in:", input);
        }
        else
        {
            Console.WriteLine("{0} can't fit in any type", input);
        }

        try
        {
            test = sbyte.Parse(input);
            Console.WriteLine("* sbyte");
        }
        catch (Exception) { ;}

        try
        {
            test = byte.Parse(input);
            Console.WriteLine("* byte");
        }
        catch (Exception) { ;}

        try
        {
            test = short.Parse(input);
            Console.WriteLine("* short");
        }
        catch (Exception) { ;}

        try
        {
            test = ushort.Parse(input);
            Console.WriteLine("* ushort");
        }
        catch (Exception) { ;}

        try
        {
            test = int.Parse(input);
            Console.WriteLine("* int");
        }
        catch (Exception) { ;}

        try
        {
            test = uint.Parse(input);
            Console.WriteLine("* uint");
        }
        catch (Exception) { ;}

        try
        {
            test = long.Parse(input);
            Console.WriteLine("* long");
        }
        catch (Exception) { ;}
    }
}