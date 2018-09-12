namespace Stealer
{
    using System;

    public class StartUp
    {
        private static void Main()
        {
            var information = new Spy().StealFieldInfo("Hacker", "username", "password");
            Console.Write(information);
        }
    }
}