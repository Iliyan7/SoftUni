﻿using System.Collections.Generic;

namespace DatabaseFirst.Data.Models
{
    public class Town
    {
        public int TownId { get; set; }

        public string Name { get; set; }

        public ICollection<Address> Addresses { get; set; } = new HashSet<Address>();
    }
}
