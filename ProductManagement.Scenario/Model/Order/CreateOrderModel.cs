using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Scenario.Model.Order
{
    public class CreateOrderModel
    {
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
    }
}
