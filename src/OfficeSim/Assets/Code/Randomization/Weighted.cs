public sealed class Weighted<T>
{
    public int Weight { get; }
    public T Item { get; }

    public Weighted(int weight, T item)
    {
        Weight = weight;
        Item = item;
    }
}
