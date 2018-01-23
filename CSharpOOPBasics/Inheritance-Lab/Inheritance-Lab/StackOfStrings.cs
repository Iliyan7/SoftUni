using System;
using System.Collections.Generic;
using System.Linq;

//namespace Inheritance_Lab
//{
class StackOfStrings
{
    private List<string> data;

    public StackOfStrings()
    {
        this.data = new List<string>();
    }

    public void Push(string item)
    {
        this.data.Insert(0, item);
    }

    public string Pop()
    {
        if (this.IsEmpty())
        {
            throw new InvalidOperationException($"{nameof(StackOfStrings)} is empty");
        }

        var removed = this.data
            .First();

        this.data.RemoveAt(0);

        return removed;
    }

    public string Peek()
    {
        if(this.IsEmpty())
        {
            throw new InvalidOperationException($"{nameof(StackOfStrings)} is empty");
        }

        return this.data
            .First();
    }

    public bool IsEmpty()
    {
        if (this.data.Count < 1)
            return true;

        return false;
    }
}
//}
