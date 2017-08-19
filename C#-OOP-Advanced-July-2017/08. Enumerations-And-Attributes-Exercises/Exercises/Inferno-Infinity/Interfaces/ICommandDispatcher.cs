using System.Collections.Generic;

public interface ICommandDispatcher
{
    void ExecuteCommand(IList<string> tokens);
}