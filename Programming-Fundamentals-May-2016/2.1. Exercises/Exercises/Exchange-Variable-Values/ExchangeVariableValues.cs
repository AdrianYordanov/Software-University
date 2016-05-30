using System;

class ExchangeVariableValues
{
    static void Main()
    {
        int firstNumber = int.Parse(Console.ReadLine());
        int secondNumber = int.Parse(Console.ReadLine());

        Console.WriteLine("Before:");
        Console.WriteLine("a = {0}", firstNumber);
        Console.WriteLine("b = {0}", secondNumber);

        int temp = firstNumber;
        firstNumber = secondNumber;
        secondNumber = temp;

        Console.WriteLine("After:");
        Console.WriteLine("a = {0}", firstNumber);
        Console.WriteLine("b = {0}", secondNumber);
    }
}