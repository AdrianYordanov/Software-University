using System;

class ComparingFloats
{
    static void Main()
    {
        double firstNumber = double.Parse(Console.ReadLine());
        double secondNumber = double.Parse(Console.ReadLine());
        double eps = 0.000001d;
        double difference = firstNumber - secondNumber;

        if(firstNumber < secondNumber)
        {
            difference = secondNumber - firstNumber;
        }

        bool areEqual = difference < eps;

        Console.WriteLine(areEqual);
    }
}