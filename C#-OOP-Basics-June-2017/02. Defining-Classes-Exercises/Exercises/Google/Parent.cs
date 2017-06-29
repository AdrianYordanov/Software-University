class Parent
{
    public Parent(string name, string birthdate)
    {
        this.Name = name;
        this.Birthdate = birthdate;
    }

    public string Name { get; set; }

    public string Birthdate { get; set; }

    public override string ToString()
    {
        return $"{this.Name} {this.Birthdate}";
    }
}