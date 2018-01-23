using FastFood.Data;
using FastFood.DataProcessor.Dto.Import;
using FastFood.Models;
using FastFood.Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace FastFood.DataProcessor
{
    public static class Deserializer
    {
        private const string FailureMessage = "Invalid data format.";
        private const string SuccessMessage = "Record {0} successfully imported.";

        public static string ImportEmployees(FastFoodDbContext context, string jsonString)
        {
            var deserializedEmployees = JsonConvert.DeserializeObject<EmployeesDto[]>(jsonString);

            var sb = new StringBuilder();
            var validEmployees = new List<Employee>();
            var validPosition = new List<Position>();

            foreach (var employeeDto in deserializedEmployees)
            {
                if (!IsValid(employeeDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var positionName = employeeDto.Position;
                var positionExists = validPosition.Any(e => e.Name == positionName);
                if (!positionExists)
                {
                    var position = new Position()
                    {
                        Name = positionName
                    };

                    validPosition.Add(position);
                }

                var employee = new Employee()
                {
                    Name = employeeDto.Name,
                    Age = employeeDto.Age,
                    Position = validPosition.Single(p => p.Name == positionName)
                };

                validEmployees.Add(employee);

                sb.AppendLine(string.Format(SuccessMessage, employeeDto.Name));
            }

            context.Employees.AddRange(validEmployees);
            context.SaveChanges();

            var result = sb.ToString();
            return result;
        }

        public static string ImportItems(FastFoodDbContext context, string jsonString)
        {
            var deserializedItems = JsonConvert.DeserializeObject<ItemDto[]>(jsonString);

            var sb = new StringBuilder();
            var validItems = new List<Item>();
            var validCategories = new List<Category>();

            foreach (var itemDto in deserializedItems)
            {
                if (!IsValid(itemDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var itemExists = validItems.Any(i => i.Name == itemDto.Name);
                if (itemExists)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var categoryName = itemDto.Category;
                var categoryExists = validCategories.Any(c => c.Name == categoryName);
                if (!categoryExists)
                {
                    var category = new Category
                    {
                        Name = categoryName
                    };

                    validCategories.Add(category);
                }

                var item = new Item()
                {
                    Name = itemDto.Name,
                    Price = itemDto.Price,
                    Category = validCategories.Single(c => c.Name == categoryName)
                };

                validItems.Add(item);

                sb.AppendLine(string.Format(SuccessMessage, itemDto.Name));
            }

            context.Items.AddRange(validItems);
            context.SaveChanges();

            var result = sb.ToString();
            return result;
        }

        public static string ImportOrders(FastFoodDbContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(OrderDto[]), new XmlRootAttribute("Orders"));
            var deserializedOrders = (OrderDto[])serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));

            var sb = new StringBuilder();
            var validOrders = new List<Order>();
            var orderItems = new List<OrderItem>();

            foreach (var orderDto in deserializedOrders)
            {
                if (!IsValid(orderDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var employeeExists = context.Employees.SingleOrDefault(e => e.Name == orderDto.Employee);
                if (employeeExists == null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var itemExists = context.Items.Any(i => orderDto.Items.Any(oi => oi.Name == i.Name));
                if (!itemExists)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var order = new Order()
                {
                    Customer = orderDto.Customer,
                    DateTime = DateTime.ParseExact(orderDto.DateTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                    Type = (OrderType)Enum.Parse(typeof(OrderType), orderDto.Type),
                    Employee = context.Employees.Single(e => e.Name == orderDto.Employee)
                };

                foreach (var itemDto in orderDto.Items)
                {
                    var item = context.Items.Single(i => i.Name == itemDto.Name);

                    var orderItem = new OrderItem()
                    {
                        Order = order,
                        Item = item,
                        Quantity = itemDto.Quantity
                    };

                    orderItems.Add(orderItem);
                }

                validOrders.Add(order);

                sb.AppendLine($"Order for {orderDto.Customer} on {orderDto.DateTime} added");
            }

            context.Orders.AddRange(validOrders);
            context.OrderItems.AddRange(orderItems);
            context.SaveChanges();

            var result = sb.ToString();
            return result;
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);

            return isValid;
        }
    }
}