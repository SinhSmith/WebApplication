using System.Collections.Generic;
using System.Linq;
using WebApplication.Infractructure.Utilities;
using WebApplication.Model.Context;

namespace WebApplication.Repository.Implements
{
    public class ProductRepository : RepositoryBase<ecom_Products>
    {
        public ProductRepository(OnlineStoreMVCEntities context) : base(context)
        {
        }

        public IEnumerable<ecom_Products> GetAllProducts()
        {
            return dbSet.ToList();
        }

        public IEnumerable<ecom_Products> GetAllProductsWithoutDelete()
        {
            return dbSet.Include("share_Images").Include("CoverImage").Where(c => c.Status != (int)Define.Status.Delete).ToList();
        }

        public ecom_Products GetProductById(int id)
        {
            return dbSet.Include("share_Images").Include("CoverImage").Where(c => c.Id == id && c.Status != (int)Define.Status.Delete).FirstOrDefault();
        }
    }
}
