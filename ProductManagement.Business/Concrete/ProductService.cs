using ProductManagement.Business.Abstract;
using ProductManagement.DataAccess.Abstract;
using ProductManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Business.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductService(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void CreateProduct(Product product)
        {
            _productDal.Create(product);
        }

        public Product GetProductByProductCode(string productCode)
        {
            return _productDal.GetOne(x => x.ProductCode == productCode);
        }
    }
}
