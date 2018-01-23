using System;

//namespace Polymorphism_Lab
//{
class Cat : Animal
{
    public Cat(string name, string favouriteFood)
    {
        this.Name = name;
        this.FavouriteFood = favouriteFood;
    }

    public override string ExplainMyself()
    {
        return base.ExplainMyself() + Environment.NewLine + "MEEOW";
    }
}
//}
