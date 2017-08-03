public interface IResident : IIdentifiable
{
    string Country { get; }

    string GetName();
}