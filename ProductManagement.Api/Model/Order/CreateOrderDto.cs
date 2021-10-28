using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Api.Model.Order
{
    public class CreateOrderDto
    {
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
    }
}
