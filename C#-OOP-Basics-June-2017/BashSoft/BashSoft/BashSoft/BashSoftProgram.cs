namespace BashSoft
{
    using IO;
    using Judge;
    using Repository;

    public class BashSoftProgram
    {
        private static void Main()
        {
            var tester = new Tester();
            var inputOutputManager = new IOManager();
            var repo = new StudentsRepository(new RepositorySorter(), new RepositoryFilter());

            var currentInterpreter = new CommandInterpreter(tester, repo, inputOutputManager);
            var reader = new InputReader(currentInterpreter);

            reader.StartReadingCommands();
        }
    }
}