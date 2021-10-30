﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Scenario.Model.Product
{
    public class CreateProductModel
    {
        public string ProductCode { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
    }
}
