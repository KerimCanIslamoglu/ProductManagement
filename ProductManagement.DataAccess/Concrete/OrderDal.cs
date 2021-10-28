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
    public class OrderDal : GenericRepository<Order, ApplicationDbContext>, IOrderDal
    {
        private ApplicationDbContext _db;

        public OrderDal(ApplicationDbContext db)
        {
            _db = db;
        }
    }
}
