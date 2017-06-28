class Person
{
    public string name;
    public int age;

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    public Person(int age)
        : this("No name", age)
    { }

    public Person()
        : this("No name", 1)
    { }
}