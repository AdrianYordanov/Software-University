using System;
using System.Reflection;

public class StartUp
{
    private static void Main()
    {
        var blackBoxClass = typeof(BlackBoxInteger);
        var blackBoxInstace = (BlackBoxInteger) Activator.CreateInstance(blackBoxClass, true);
        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            var inputTokens = input.Split(new[] {'_'}, StringSplitOptions.RemoveEmptyEntries);
            var inputMethod = inputTokens[0];
            var inputValue = int.Parse(inputTokens[1]);
            switch (inputMethod)
            {
                case "Add":
                case "Subtract":
                case "Multiply":
                case "Divide":
                case "LeftShift":
                case "RightShift":
                    BlackBoxMethodInovkation(blackBoxInstace,
                        blackBoxClass.GetMethod(inputMethod, BindingFlags.Instance | BindingFlags.NonPublic),
                        inputValue);
                    Console.WriteLine(blackBoxClass
                       .GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic)
                       .GetValue(blackBoxInstace));
                    break;
            }
        }
    }

    private static void BlackBoxMethodInovkation(BlackBoxInteger instance, MethodInfo method, int value)
    {
        method.Invoke(instance, new object[] {value});
    }
}