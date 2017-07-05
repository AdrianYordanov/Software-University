class Cat
{
    private string name;

    public Cat(string name)
    {
        this.Name = name;
    }
    public string Name
    {
        get { return this.name; }
        private set { this.name = value; }
    }
}