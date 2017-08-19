using System.Collections.Generic;

public interface IInputHandler
{
    List<string> SplitInput(string input, string splitValue);
}