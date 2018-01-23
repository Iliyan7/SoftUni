using FastFood.Data;
using FastFood.DataProcessor.Dto.Export;
using FastFood.Models.Enums;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace FastFood.DataProcessor
{
    public class Serializer
    {
        public static string ExportOrdersByEmployee(FastFoodDbContext context, string employeeName, string orderType)
        {
            var employeeOrders = new EmployeeOrders
            {
                Name = employeeName,
                Orders = context.Employees
                .Single(e => e.Name == employeeName)
                .Orders
                .Where(o => o.Type == Enum.Parse<OrderType>(orderType))
                .Select(o => new OrderDto
                {
                    Customer = o.Customer,
                    Items = o.OrderItems.Select(oi => new ItemDto
                    {
                        Name = oi.Item.Name,
                        Price = Decimal.Parse(string.Format($"{oi.Item.Price:F2}")),
                        Quantity = oi.Quantity
                    })
                    .ToArray(),
                    TotalPrice = Decimal.Parse(string.Format($"{o.TotalPrice:F2}"))
                })
                .OrderByDescending(o => o.TotalPrice)
                .ThenByDescending(o => o.Items.Length)
                .ToArray()
            };

            employeeOrders.TotalMade = employeeOrders.Orders.Sum(o => Decimal.Parse(string.Format($"{o.TotalPrice:F2}")));

            var jsonString = JsonConvert.SerializeObject(employeeOrders, Newtonsoft.Json.Formatting.Indented);
            return jsonString;
        }

        public static string ExportCategoryStatistics(FastFoodDbContext context, string categoriesString)
        {
            var categoriesToExport = categoriesString.Split(',');

            var categories = context.Categories
                .Where(c => categoriesToExport.Contains(c.Name))
                .Select(c => new CategoryDto
                {
                    Name = c.Name,
                    MostPopularItem = c.Items.Select(i => new MostPopularItemDto
                    {
                        Name = i.Name,
                        TotalMade = i.Price * i.OrderItems.Sum(oi => oi.Quantity),
                        TimesSold = i.OrderItems.Sum(oi => oi.Quantity)
                    })
                    .OrderByDescending(i => i.TotalMade)
                    .First()
                })
                .OrderByDescending(c => c.MostPopularItem.TotalMade)
                .ToArray();

            var sb = new StringBuilder();

            var serializer = new XmlSerializer(typeof(CategoryDto[]), new XmlRootAttribute("Categories"));
            serializer.Serialize(new StringWriter(sb), categories, new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty }));

            var result = sb.ToString();
            return result;
        }
    }
}