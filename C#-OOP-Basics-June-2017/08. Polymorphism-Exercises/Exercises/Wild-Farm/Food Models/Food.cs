abstract class Food
{
    private int quantity;

    public Food(int quantity)
    {
        this.Quantity = quantity;
    }

    public int Quantity
    {
        get
        {
            return this.quantity;
        }
        protected set
        {
            this.quantity = value;
        }
    }
}