public class Room
{
    private Pet sickPet;

    public Room()
    {
        this.SickPet = null;
    }

    public Pet SickPet
    {
        get => this.sickPet;
        set => this.sickPet = value;
    }

    private bool IsEmpty => this.SickPet == null;

    public override string ToString()
    {
        return this.IsEmpty ? $"Room empty" : this.SickPet.ToString();
    }
}