using LinearDataStuctures;

namespace StartUp
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList<int> list = new ArrayList<int>();
            list.Add(5);
            list.Add(6);
            list.Add(7);
            list.Add(8);
            int element = list.RemoveAt(0);
        }
    }
}
