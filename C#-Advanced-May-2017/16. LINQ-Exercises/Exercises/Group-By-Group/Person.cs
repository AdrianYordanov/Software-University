public class Person
{
    public Person(string name, int group)
    {
        this.Name = name;
        this.Group = group;
    }

    public int Group { get; set; }

    public string Name { get; set; }
}