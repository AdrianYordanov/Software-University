using System.Collections.Generic;

public interface ILeutenantGeneral : IPrivate
{
    IList<string> Privates { get; }
}