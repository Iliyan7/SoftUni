using System.Collections.Generic;

namespace StrategyPattern.Comparators
{
    public class AgeComparator : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return x.Age - y.Age;
        }
    }
}
