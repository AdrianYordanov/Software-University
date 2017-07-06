using System;

class Dog : Animal
{
    public Dog(string name, string favouriteFoold)
        : base(name, favouriteFoold)
    { }

    public override string ExplainMyself()
    {
        return base.ExplainMyself() + Environment.NewLine + "DJAAF";
    }
}