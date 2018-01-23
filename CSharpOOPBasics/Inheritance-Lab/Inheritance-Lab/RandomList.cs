using System;
using System.Collections;

//namespace Inheritance_Lab
//{
class RandomList : ArrayList
{
    private Random rnd = new Random();

    public string RandomString()
    {
        return base[rnd.Next(base.Count)].
            ToString();
    }
}
//}
