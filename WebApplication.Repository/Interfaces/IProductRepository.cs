using System.Collections.Generic;
using WebApplication.Model.Context;

namespace WebApplication.Repository.Interfaces
{
    public interface IProductRepository : IRepositoryBase<ecom_Products>
    {
        IEnumerable<ecom_Products> GetAllProducts();
        IEnumerable<ecom_Products> GetAllProductsWithoutDelete();
        ecom_Products GetProductById(int id);
    }
}
