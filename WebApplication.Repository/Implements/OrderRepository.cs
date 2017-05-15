using System.Collections.Generic;
using System.Linq;
using WebApplication.Infractructure.Utilities;
using WebApplication.Model.Context;
using WebApplication.Repository.Interfaces;

namespace WebApplication.Repository.Implements
{
    public class OrderRepository : RepositoryBase<ecom_Orders>, IOrderRepository
    {
        public OrderRepository(OnlineStoreMVCEntities context) : base(context)
        {
        }

        public IEnumerable<ecom_Orders> GetAllOrders()
        {
            return dbSet.Where(o => o.Status == (int)Define.Status.Active).ToList();
        }
    }
}
