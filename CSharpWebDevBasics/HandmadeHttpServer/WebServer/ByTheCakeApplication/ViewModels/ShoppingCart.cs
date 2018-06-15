using System.Collections.Generic;

namespace WebServer.ByTheCakeApplication.ViewModels
{
    public class ShoppingCart
    {
        public const string SessionKey = "%^Current_Shopping_Cart^%";

        public List<int> ProductIds { get; } = new List<int>();
    }
}
