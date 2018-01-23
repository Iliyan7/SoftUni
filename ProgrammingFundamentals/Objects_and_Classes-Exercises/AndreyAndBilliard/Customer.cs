using System.Collections.Generic;

namespace AndreyAndBilliard
{
    class Customer
    {
        public string Name { get; set; }

        public Dictionary<string, int> ShopList { get; set; }

        public decimal Bill { get; set; }
    }
}
