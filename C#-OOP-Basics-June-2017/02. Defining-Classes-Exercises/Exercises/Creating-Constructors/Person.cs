public class Person
{
    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public Person(int age)
        : this("No name", age)
    {
    }

    public Person()
        : this("No name", 1)
    {
    }

    public string Name { get; }

    public int Age { get; }
}