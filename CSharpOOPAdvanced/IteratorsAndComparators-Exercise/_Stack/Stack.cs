using System;
using System.Collections;
using System.Collections.Generic;

namespace _Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private const int defaultSize = 8;

        private T[] array;
        private int size;

        public Stack()
        {
            this.array = new T[defaultSize];
        }

        public void Push(params T[] elements)
        {
            foreach (var element in elements)
            {
                if (this.size >= this.array.Length)
                {
                    Array.Resize<T>(ref this.array, this.size * 2);
                }

                this.array[this.size++] = element;
            }
        }

        public T Pop()
        {
            if(this.size == 0)
            {
                throw new InvalidOperationException("No elements");
            }

            T poppedElement = this.array[--this.size];

            this.array[this.size] = default(T);

            return poppedElement;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.size - 1; i >= 0; i--)
            {
                yield return array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
