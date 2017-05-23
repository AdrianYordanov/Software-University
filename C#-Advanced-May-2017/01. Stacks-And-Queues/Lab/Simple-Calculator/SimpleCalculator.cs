using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SimpleCalculator
{
    static void Main()
    {
        var input = Console.ReadLine();
        var tokens = input.Split(' ');
        var stack = new Stack<double>();


        for (int i = 0; i < tokens.Length; i++)
        {
            if (stack.Count == 0)
            {
                stack.Push(double.Parse(tokens[i]));
            }
            else
            {
                var operation = tokens[i];
                i++;

                switch (operation)
                {
                    case "+": stack.Push(stack.Pop() + double.Parse(tokens[i])); break;
                    case "-": stack.Push(stack.Pop() - double.Parse(tokens[i])); break;
                }
            }
        }

        Console.WriteLine(stack.Pop());
    }
}