public class CustomTuple<TFirstItem, TSecondItem>
{
    private TFirstItem firstItem;
    private TSecondItem secondItem;

    public CustomTuple(TFirstItem firstItem, TSecondItem secondItem)
    {
        this.FirstItem = firstItem;
        this.SecondItem = secondItem;
    }

    public TFirstItem FirstItem
    {
        get => this.firstItem;
        set => this.firstItem = value;
    }

    public TSecondItem SecondItem
    {
        get => this.secondItem;
        set => this.secondItem = value;
    }

    public override string ToString()
    {
        return $"{this.FirstItem} -> {this.SecondItem}";
    }
}