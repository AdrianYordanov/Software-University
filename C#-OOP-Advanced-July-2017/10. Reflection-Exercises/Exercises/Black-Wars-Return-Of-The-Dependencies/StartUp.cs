namespace Black_Wars_Return_Of_The_Dependencies
{
    using Contracts;
    using Core;
    using Core.Factories;
    using Data;

    public class StartUp
    {
        private static void Main()
        {
            IRepository repository = new UnitRepository();
            IUnitFactory unitFactory = new UnitFactory();
            IRunnable engine = new Engine(repository, unitFactory);
            engine.Run();
        }
    }
}