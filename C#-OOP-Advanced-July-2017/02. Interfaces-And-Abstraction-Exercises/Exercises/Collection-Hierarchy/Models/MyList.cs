public class MyList : Collection, IMyList
{
    public int Used => this.List.Count;

    public int Add(string str)
    {
        this.List.Insert(0, str);
        return 0;
    }

    public string Remove()
    {
        var last = this.List[0];
        this.List.RemoveAt(0);
        return last;
    }
}