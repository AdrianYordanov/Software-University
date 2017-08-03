public class AddRemoveCollection : Collection, IAddRemoveCollection
{
    public int Add(string str)
    {
        this.List.Insert(0, str);
        return 0;
    }

    public string Remove()
    {
        var last = this.List[this.List.Count - 1];
        this.List.RemoveAt(this.List.Count - 1);
        return last;
    }
}