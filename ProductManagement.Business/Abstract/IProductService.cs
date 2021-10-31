using ProductManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Business.Abstract
{
    public interface IProductService
    {
        Product GetProductByProductCode(string productCode);
        Product CreateProduct(Product product);
        void Update(Product product);
    }
}
