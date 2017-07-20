public static class ArrayCreator
{
    public static T[] Create<T>(int count, T element)
    {
        return new T[count];
    }
}