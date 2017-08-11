public class LinkedListNode<T>
{
    private T value;
    private LinkedListNode<T> next;

    public LinkedListNode(T value)
    {
        this.Value = value;
    }

    public T Value
    {
        get => this.value;
        private set => this.value = value;
    }

    public LinkedListNode<T> Next
    {
        get => this.next;
        set => this.next = value;
    }
}