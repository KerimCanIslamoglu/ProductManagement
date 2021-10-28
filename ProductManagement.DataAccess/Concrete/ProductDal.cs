using ProductManagement.DataAccess.Abstract;
using ProductManagement.DataAccess.Context;
using ProductManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.DataAccess.Concrete
{
    public class ProductDal : GenericRepository<Product, ApplicationDbContext>, IProductDal
    {
        private ApplicationDbContext _db;

        public ProductDal(ApplicationDbContext db)
        {
            _db = db;
        }
    }
}
