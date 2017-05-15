using System.Collections.Generic;
using System.Linq;
using WebApplication.Infractructure.Utilities;
using WebApplication.Model.Context;
using WebApplication.Repository.Implements;
using WebApplication.Repository.Interfaces;

namespace WebApplication.Repository.Implements
{
    public class BrandRepository : RepositoryBase<ecom_Brands>, IBrandRepository
    {
        public BrandRepository(OnlineStoreMVCEntities context) : base(context)
        {

        }

        public IList<ecom_Brands> GetAllAvailableBrands()
        {
            return dbSet.Where(b => b.Status != (int)Define.Status.Delete).ToList();
        }
    }
}
