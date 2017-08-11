using System;

public class Person : IComparable<Person>
{
    private string name;
    private int age;
    private string town;

    public Person(string name, int age, string town)
    {
        this.Name = name;
        this.Age = age;
        this.Town = town;
    }

    public string Name
    {
        get => this.name;
        private set => this.name = value;
    }

    public int Age
    {
        get => this.age;
        private set => this.age = value;
    }

    public string Town
    {
        get => this.town;
        private set => this.town = value;
    }

    public int CompareTo(Person other)
    {
        var result = string.Compare(this.Name, other.Name, StringComparison.Ordinal);
        if (result == 0)
        {
            result = this.Age.CompareTo(other.Age);
            if (result == 0)
            {
                result = string.Compare(this.Town, other.Town, StringComparison.Ordinal);
            }
        }

        return result;
    }
}