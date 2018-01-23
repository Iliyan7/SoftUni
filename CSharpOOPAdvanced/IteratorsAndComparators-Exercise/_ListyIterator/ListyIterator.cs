using System;
using System.Collections.Generic;

namespace _ListyIterator
{
    public class ListyIterator<T>
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
            if(this.HasNext())
            {
                this.index++;
                return true;
            }

            return false;
        }

        public void Print()
        {
            if(this.list.Count == 0)
            {
                throw new ArgumentException("Invalid Operation!");
            }

            Console.WriteLine(this.list[this.index]);
        }
    }
}
