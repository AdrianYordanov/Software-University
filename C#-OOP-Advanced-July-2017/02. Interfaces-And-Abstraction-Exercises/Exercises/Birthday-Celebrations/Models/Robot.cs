public class Robot : IIdentifiable, IName
{
    private string id;
    private string name;

    public Robot(string name, string id)
    {
        this.Name = name;
        this.Id = id;
    }

    public string Id
    {
        get => this.id;
        private set => this.id = value;
    }

    public string Name
    {
        get => this.name;
        private set => this.name = value;
    }
}