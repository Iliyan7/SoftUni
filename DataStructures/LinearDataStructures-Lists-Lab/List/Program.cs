using System;

public class Program
{
    public static void Main()
    {
        var list = new ArrayList<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);

        Console.WriteLine(list[1]);
        Console.WriteLine(list.RemoveAt(1));
        Console.WriteLine(list.Count);
    }
}

