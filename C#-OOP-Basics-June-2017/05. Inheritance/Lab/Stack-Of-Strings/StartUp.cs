using System;

class StartUp
{
    static void Main()
    {
        var stack = new StackOfStrings();
        stack.Push("1");
        stack.Push("2");
        Console.WriteLine(stack.IsEmpty());
        Console.WriteLine(stack.Peek());
        Console.WriteLine(stack.Pop());
        Console.WriteLine(stack.Peek());
        stack.Pop();
        Console.WriteLine(stack.IsEmpty());
    }
}