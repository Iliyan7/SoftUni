using System;

public class ArrayList<T>
{
    private const int Initial_Capacity = 2;

    private T[] items;

    public ArrayList()
    {
        this.items = new T[Initial_Capacity];
    }

    public int Count { get; set; }

    public T this[int index]
    {
        get
        {
            if (index > this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            return this.items[index];
        }

        set
        {
            if (index > this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.items[index] = value;
        }
    }

    public void Add(T item)
    {
        if (this.Count == this.items.Length)
        {
            this.Resize();
        }

        this.items[this.Count++] = item;
    }

    private void Resize()
    {
        Array.Resize<T>(ref this.items, this.items.Length * 2);
    }

    public T RemoveAt(int index)
    {
        if (index >= this.Count)
        {
            throw new ArgumentOutOfRangeException();
        }

        var elemnet = this.items[index];
        this.items[index] = default(T);
        this.Shift(index);
        this.Count--;

        if (this.Count < this.items.Length / 4)
        {
            this.Shrink();
        }

        return elemnet;
    }

    private void Shift(int index)
    {
        for (int i = index; i < this.Count; i++)
        {
            this.items[i] = this.items[i + 1];
        }
    }

    private void Shrink()
    {
        Array.Resize<T>(ref this.items, this.items.Length / 2);
    }
}
