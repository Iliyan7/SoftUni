using System;
using System.Collections;
using System.Collections.Generic;

//namespace _01LinkedList
//{
public class LinkedList<T> : IEnumerable<T>
{
    public Node Head { get; private set; }
    public Node Tail { get; private set; }
    public int Count { get; private set; }

    public void AddFirst(T item)
    {
        Node old = this.Head;

        this.Head = new Node(item);
        this.Head.Next = old;

        if(this.IsEmpty())
        {
            this.Tail = this.Head;
        }

        this.Count++;
    }

    public void AddLast(T item)
    {
        Node old = this.Tail;
        this.Tail = new Node(item);

        if (this.IsEmpty())
        {
            this.Head = this.Tail;
        }
        else
        {
            old.Next = this.Tail;
        }

        this.Count++;
    }

    public T RemoveFirst()
    {
        if(this.IsEmpty())
        {
            throw new InvalidOperationException();
        }

        var item = this.Head.Value;
        this.Head = this.Head.Next;
        this.Count--;

        if(this.IsEmpty())
        {
            this.Tail = null;
        }

        return item;
    }

    public T RemoveLast()
    {
        if (this.IsEmpty())
        {
            throw new InvalidOperationException();
        }

        var item = this.Tail.Value;

        if(this.Count == 1)
        {
            this.Head = this.Tail = null;
        }
        else
        {
            var newTail = this.GetSecondToLast();
            newTail.Next = null;
            this.Tail = newTail;
        }

        this.Count--;

        return item;
    }

    private Node GetSecondToLast()
    {
        var node = this.Head;
        while(node != this.Tail)
        {
            node = node.Next;
        }

        return node;
    }

    private bool IsEmpty()
    {
        return this.Count == 0;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var node = this.Head;
        while (node != null)
        {
            yield return node.Value;
            node = node.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public class Node
    {
        public Node(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }
        public Node Next { get; set; }
    }
}
//}