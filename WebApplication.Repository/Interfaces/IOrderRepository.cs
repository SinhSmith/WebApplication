using System.Collections.Generic;
using WebApplication.Model.Context;

namespace WebApplication.Repository.Interfaces
{
    public interface IOrderRepository : IRepositoryBase<ecom_Orders>
    {
        IEnumerable<ecom_Orders> GetAllOrders();
    }
}
