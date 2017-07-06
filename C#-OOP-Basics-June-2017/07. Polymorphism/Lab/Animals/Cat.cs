using System;

class Cat : Animal
{
    public Cat(string name, string favouriteFoold)
        : base(name, favouriteFoold)
    { }

    public override string ExplainMyself()
    {
        return base.ExplainMyself() + Environment.NewLine + "MEEOW";
    }
}