using System;

//namespace Polymorphism_Lab
//{
class Dog : Animal
{
    public Dog(string name, string favouriteFood)
    {
        this.Name = name;
        this.FavouriteFood = favouriteFood;
    }

    public override string ExplainMyself()
    {
        return base.ExplainMyself() + Environment.NewLine + "DJAAF";
    }
}
//}
