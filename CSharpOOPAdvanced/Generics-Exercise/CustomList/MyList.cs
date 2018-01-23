using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CustomList
{
    public class MyList<T> : IMyList<T>, IEnumerable<T>
        where T : IComparable<T>
    {
        private readonly IList<T> elements;

        public MyList()
            : this(Enumerable.Empty<T>())
        {
        }

        public MyList(IEnumerable<T> collection)
        {
            this.elements = new List<T>(collection);
        }

        public void Add(T element)
        {
            this.elements.Add(element);
        }

        public T Remove(int index)
        {
            var removed = this.elements[index];
            this.elements.RemoveAt(index);
            return removed;
        }

        public bool Contains(T element) => this.elements.Contains(element);

        public void Swap(int index1, int index2)
        {
            T tempElement = this.elements[index1];
            this.elements[index1] = this.elements[index2];
            this.elements[index2] = tempElement;
        }

        public int CountGreaterThan(T element)
        {
            return this.elements.Count(e => e.CompareTo(element) > 0);
        }

        public T Max() => this.elements.Max();

        public T Min() => this.elements.Min();

        public IEnumerator<T> GetEnumerator()
        {
            return this.elements.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}