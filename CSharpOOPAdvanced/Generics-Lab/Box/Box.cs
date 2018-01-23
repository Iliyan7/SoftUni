using System;
using System.Linq;

//namespace Box
//{
class Box<T>
{
    private const int defaultSize = 4;

    private T[] array;
    private int size;

    public Box()
    {
        this.array = new T[defaultSize];
    }

    public int Count
    {
        get { return this.size; }
    }

    public void Add(T element)
    {
        if(this.size >= this.array.Length)
        {
            Array.Resize<T>(ref this.array, this.size * 2);
        }

        this.array[this.size++] = element;
    }

    public T Remove()
    {
        T removedElement = this.array[--this.size];
        this.array = this.array
            .Where((source, index) => index != this.size)
            .ToArray();

        return removedElement;
    }
}
//}
