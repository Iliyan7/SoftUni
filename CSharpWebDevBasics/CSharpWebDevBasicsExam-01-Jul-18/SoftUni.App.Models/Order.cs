using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftUni.App.Models
{
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id{ get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int ClientId { get; set; }

        public User Client { get; set; }

        public DateTime OrderedOn { get; set; }
    }
}
