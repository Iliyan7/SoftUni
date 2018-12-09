using System;

namespace LinearDataStuctures
{
    public class CircularQueue<T>
    {
        private const int DefaultCapacity = 4;

        private T[] elements;
        private int startIndex;
        private int endIndex;

        public CircularQueue(int capacity = DefaultCapacity)
        {
            this.elements = new T[capacity];
        }

        public int Count { get; private set; }

        public void Enqueue(T element)
        {
            if (this.Count >= this.elements.Length)
            {
                this.Grow();
            }

            this.elements[this.endIndex] = element;
            this.endIndex = (this.endIndex + 1) % this.elements.Length;
            this.Count++;
        }

        private void Grow()
        {
            var newElements = new T[2 * this.elements.Length];
            this.CopyAllElementsTo(newElements);
            this.elements = newElements;
            this.startIndex = 0;
            this.endIndex = this.Count;
        }

        private void CopyAllElementsTo(T[] newElements)
        {
            var sourceIndex = this.startIndex;
            var destinationIndex = 0;
            for (int i = 0; i < this.Count; i++)
            {
                newElements[destinationIndex] = this.elements[sourceIndex];
                sourceIndex = (sourceIndex + 1) % this.elements.Length;
                destinationIndex++;
            }
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty!");
            }

            var result = this.elements[startIndex];
            this.startIndex = (this.startIndex + 1) % this.elements.Length;
            this.Count--;

            return result;
        }

        public T[] ToArray()
        {
            var resultArr = new T[this.Count];
            this.CopyAllElementsTo(resultArr);
            return resultArr;
        }
    }
}
