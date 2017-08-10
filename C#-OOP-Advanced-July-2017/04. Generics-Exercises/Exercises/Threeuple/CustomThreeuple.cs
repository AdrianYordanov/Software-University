public class CustomThreeuple<TFirstItem, TSecondItem, TThirdItem>
{
    private TFirstItem firstItem;
    private TSecondItem secondItem;
    private TThirdItem thirdItem;

    public CustomThreeuple(TFirstItem firstItem, TSecondItem secondItem, TThirdItem thirdItem)
    {
        this.FirstItem = firstItem;
        this.SecondItem = secondItem;
        this.ThirdItem = thirdItem;
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

    public TThirdItem ThirdItem
    {
        get => this.thirdItem;
        set => this.thirdItem = value;
    }

    public override string ToString()
    {
        return $"{this.FirstItem} -> {this.SecondItem} -> {this.ThirdItem}";
    }
}