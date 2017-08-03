public class AddCollection : Collection, IAddCollection
{
    public int Add(string str)
    {
        this.List.Add(str);
        return this.List.Count - 1;
    }
}