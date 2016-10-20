using System;

class VariableInHexadecimalFormat
{
    static void Main()
    {
        string hexadecimalFormat = Console.ReadLine();
        int decimalFormat = Convert.ToInt32(hexadecimalFormat, 16);

        Console.WriteLine(decimalFormat);
    }
}