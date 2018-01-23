using System;
using System.Linq;

namespace CustomList
{
    public class Sorter
    {
        public static MyList<T> Sort<T>(MyList<T> customList)
            where T : IComparable<T>
        {
            return new MyList<T>(customList.OrderBy(x => x));
        }
    }
}