using System.Collections;
using System.Collections.Generic;

namespace Froggy
{
    public class Lake : IEnumerable<int>
    {
        private int[] numbers;

        public Lake(int[] numbers)
        {
            this.numbers = numbers;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.numbers.Length; i += 2)
            {
                yield return this.numbers[i];
            }

            var lastNumber = (this.numbers.Length % 2 == 0) ? this.numbers.Length - 1 : this.numbers.Length - 2;

            for (int i = lastNumber; i >= 0; i -= 2)
            {
                yield return this.numbers[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
