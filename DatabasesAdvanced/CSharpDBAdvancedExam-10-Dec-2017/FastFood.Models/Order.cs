using FastFood.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FastFood.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public string Customer { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        public OrderType Type { get; set; }

        [NotMapped]
        [Required]
        public decimal TotalPrice
        {
            get
            {
                var total = 0m;

                foreach (var oi in this.OrderItems)
                {
                    total += oi.Item.Price * oi.Quantity;
                }

                return total;
            }
            set
            {
                TotalPrice = value;
            }
            
        }

        public int EmployeeId { get; set; }

        [Required]
        public Employee Employee { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

    }
}
