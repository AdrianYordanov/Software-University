abstract class AbstractEntity
{
    private string id;

    protected AbstractEntity(string id)
    {
        this.Id = id;
    }

    public string Id
    {
        get
        {
            return this.id;
        }
        protected set
        {
            this.id = value;
        }
    }
}