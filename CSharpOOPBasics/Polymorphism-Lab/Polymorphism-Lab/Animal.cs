using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace Polymorphism_Lab
//{
class Animal
{
    private string name;
    private string favouriteFood;

    public string Name
    {
        get { return this.name; }
        protected set { this.name = value; }
    }

    public string FavouriteFood
    {
        get { return this.favouriteFood; }
        protected set { this.favouriteFood = value; }
    }

    public virtual string ExplainMyself()
    {
        return $"I am {this.Name} and my fovourite food is {this.FavouriteFood}";
    }
}
//}
