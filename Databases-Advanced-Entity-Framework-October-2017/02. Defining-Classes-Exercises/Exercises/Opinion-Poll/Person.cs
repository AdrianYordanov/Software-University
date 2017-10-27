public class Person
{
    public string Name;
    public int Age;

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

    public override string ToString()
    {
        return $"{this.Name} - {this.Age}";
    }
}