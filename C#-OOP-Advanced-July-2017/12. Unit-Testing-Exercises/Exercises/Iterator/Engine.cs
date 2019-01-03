namespace Iterator
{
    using System;
    using Read;
    using Write;

    public class Engine
    {
        public void Run(IWriter writer, IReader reader)
        {
            var input = reader.Read();
            var firstCommandTokens = input.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            var iterator = new Iterator(firstCommandTokens);
            var iteratorType = typeof(Iterator);
            while ((input = Console.ReadLine().Trim()) != "END")
            {
                if (input == "HasNext")
                {
                    writer.Write(iterator.HasNext.ToString());
                }
                else if ((input == "Print") || (input == "Move"))
                {
                    var member = iteratorType.GetMethod(input).Invoke(iterator, null);
                    writer.Write(member.ToString());
                }
            }
        }
    }
}