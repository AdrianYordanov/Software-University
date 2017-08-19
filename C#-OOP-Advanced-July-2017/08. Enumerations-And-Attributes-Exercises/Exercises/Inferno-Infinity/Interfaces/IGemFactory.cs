using System.Collections.Generic;

public interface IGemFactory
{
    IBaseGem Create(IList<string> tokens);
}