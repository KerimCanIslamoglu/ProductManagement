using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Api.Model.Product
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
    }
}
