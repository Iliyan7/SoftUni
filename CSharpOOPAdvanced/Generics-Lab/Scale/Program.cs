using System;

//namespace Scale
//{
class Program
{
    public static void Main()
    {
        var stringScale = new Scale<string>("a", "c");
        Console.WriteLine(stringScale.GetHavier());
        var integerScale = new Scale<int>(1, 2);
        Console.WriteLine(integerScale.GetHavier());
    }
}
//}
