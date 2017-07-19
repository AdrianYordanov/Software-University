public interface ICar
{
    string Driver { get; }

    string Model { get; }

    string Gas();

    string Brake();
}