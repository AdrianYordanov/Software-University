public interface IPerson : IIdentifiable
{
    int Age { get; }

    string GetName();
}