public class Robot : IIdentifiable, IName
{
    private string name;
    private string id;

    public Robot(string name, string id)
    {
        this.Name = name;
        this.Id = id;
    }

    public string Name
    {
        get => this.name;
        private set => this.name = value;
    }

    public string Id
    {
        get => this.id;
        private set => this.id = value;
    }
}