using System;

//namespace Box
//{
class Program
{
    public static void Main()
    {
        Box<int> box = new Box<int>();
        box.Add(1);
        box.Add(2);
        box.Add(3);
        box.Add(4);
        box.Add(5);
        box.Add(6);
        box.Add(7);
        box.Add(8);
        box.Add(9);

        Console.WriteLine(box.Count);
    }
}
//}
