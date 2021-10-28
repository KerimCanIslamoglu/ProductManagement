using ProductManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.DataAccess.Abstract
{
    public interface IProductDal : IRepositoryBase<Product>
    {
    }
}
