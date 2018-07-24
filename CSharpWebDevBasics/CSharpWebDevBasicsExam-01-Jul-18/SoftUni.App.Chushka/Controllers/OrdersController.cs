using SoftUni.App.Chushka.ViewModels;
using SoftUni.App.Data;
using SoftUni.WebServer.Mvc.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUni.App.Chushka.Controllers
{
    public class OrdersController : BaseController
    {
        public IActionResult All()
        {
            if (!this.IsAdmin)
            {
                return this.RedirectToHomePage();
            }

            IList<AllOrdersViewModel> orders;

            using (var db = new ChushkaDbContext())
            {
                orders = db.Orders
                    .Select(o => new AllOrdersViewModel()
                    {
                        OrderId = o.Id.ToString(),
                        Customer = o.Client.FullName,
                        Product = o.Product.Name,
                        OrderedOn = o.OrderedOn.ToString("HH:mm dd/MM/yyyy")
                    })
                    .ToList();
            }

            var ordersResult = new StringBuilder();
            for (int i = 0; i < orders.Count; i++)
            {
                var order = orders[i];
                ordersResult.AppendLine($@"<tr>
                        <th scope=""row"">{i + 1}</th>
                        <td>{order.OrderId}</td>
                        <td>{order.Customer}</td>
                        <td>{order.Product}</td>
                        <td>{order.OrderedOn}</td>
                    </tr>");
            }

            this.ViewData["orders"] = ordersResult.ToString();

            return this.View();
        }
    }
}
