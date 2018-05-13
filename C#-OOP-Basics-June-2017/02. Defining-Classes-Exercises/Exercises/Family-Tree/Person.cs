using System.Collections.Generic;
using System.Linq;

public class Person
{
    public Person()
    {
        this.Children = new List<Person>();
    }

    public Person(string name, string date)
        : this()
    {
        this.Name = name;
        this.BirthDate = date;
    }

    public List<Person> Children { get; }

    public string Name { get; set; }

    public string BirthDate { get; set; }

    public void AddChild(Person child)
    {
        this.Children.Add(child);
    }

    public void AddChildrenInfo(string name, string date)
    {
        if (this.Children.FirstOrDefault(c => c.Name == name) != null)
        {
            this.Children.FirstOrDefault(c => c.Name == name).BirthDate = date;
        }
        else if (this.Children.FirstOrDefault(c => c.BirthDate == date) != null)
        {
            this.Children.FirstOrDefault(c => c.BirthDate == date).Name = name;
        }
    }

    public Person FindChildName(string childName)
    {
        return this.Children.FirstOrDefault(c => c.Name == childName);
    }
}