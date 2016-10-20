using System;

class BooleanVariable
{
    static void Main()
    {
        string input = Console.ReadLine();
        bool converted = Convert.ToBoolean(input);

        if(converted)
        {
            Console.WriteLine("Yes");
        }
        else
        {
            Console.WriteLine("No");
        }
    }
}