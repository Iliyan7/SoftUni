using System;
using System.Collections;
using System.Collections.Generic;

namespace Collection
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private IList<T> list;
        private int index;

        public ListyIterator(IList<T> list)
        {
            this.list = list;
        }

        public bool HasNext()
        {
            return this.index < this.list.Count - 1;
        }

        public bool Move()
        {
            if (this.HasNext())
            {
                this.index++;
                return true;
            }

            return false;
        }

        public void Print()
        {
            if (this.list.Count == 0)
            {
                throw new ArgumentException("Invalid Operation!");
            }

            Console.WriteLine(this.list[this.index]);
        }

        public void PrintAll()
        {
            if (this.list.Count == 0)
            {
                throw new ArgumentException("Invalid Operation!");
            }

            Console.WriteLine(string.Join(" ", this.list));
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < list.Count; i++)
            {
                yield return list[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}