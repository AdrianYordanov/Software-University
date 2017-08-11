using System;
using System.Linq;

public class Person : IComparable<Person>
{
    private string name;
    private int age;

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public string Name
    {
        get => this.name;
        set => this.name = value;
    }

    public int Age
    {
        get => this.age;
        set => this.age = value;
    }

    public int CompareTo(Person other)
    {
        var result = string.Compare(this.Name, other.Name, StringComparison.Ordinal);
        if (result == 0)
        {
            result = this.Age.CompareTo(other.Age);
        }
        return result;
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Age}";
    }

    public override bool Equals(object obj)
    {
        if (!(obj is Person))
        {
            return false;
        }

        var asPerson = (Person) obj;
        return this.CompareTo(asPerson) == 0;
    }

    public override int GetHashCode()
    {
        return this.Name.Sum(character => character) + this.Age;
    }
}