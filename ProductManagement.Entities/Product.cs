using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }

        public ICollection<Order> Orders { get; set; }
        public ICollection<Campaign> Campaigns { get; set; }

    }
}
