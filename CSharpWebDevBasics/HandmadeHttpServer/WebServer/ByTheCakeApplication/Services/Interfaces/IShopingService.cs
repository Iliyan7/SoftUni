using System.Collections.Generic;

namespace WebServer.ByTheCakeApplication.Services.Interfaces
{
    public interface IShoppingService
    {
        void CreateOrder(int userId, IEnumerable<int> productIds);
    }
}
