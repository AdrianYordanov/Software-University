namespace Black_Wars_Return_Of_The_Dependencies.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Field)]
    public class InjectAttribute : Attribute
    {
        public InjectAttribute()
        {
        }
    }
}
