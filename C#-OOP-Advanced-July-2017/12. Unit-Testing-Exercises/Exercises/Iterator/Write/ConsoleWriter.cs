namespace Iterator.Write
{
    using System;

    public class ConsoleWriter : IWriter
    {
        public void Write(string input)
        {
            Console.WriteLine(input);
        }
    }
}