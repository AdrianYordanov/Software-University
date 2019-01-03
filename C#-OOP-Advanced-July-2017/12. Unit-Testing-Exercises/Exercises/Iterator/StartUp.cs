namespace Iterator
{
    using Read;
    using Write;

    public class StartUp
    {
        private static void Main()
        {
            new Engine().Run(new ConsoleWriter(), new ConsoleReader());
        }
    }
}