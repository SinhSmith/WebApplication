using System.Collections.Generic;
using System.Linq;
using WebApplication.Infractructure.Utilities;
using WebApplication.Model.Context;
using WebApplication.Repository.Implements;

namespace WebApplication.Repository.Implements
{
    public class ProductGroupRepository : RepositoryBase<ecom_ProductGroups>
    {
        public ProductGroupRepository(OnlineStoreMVCEntities context) : base(context)
        {
        }

        public IList<ecom_ProductGroups> GetAllAvailableGroups()
        {
            return dbSet.Where(b => b.Status != (int)Define.Status.Delete).ToList();
        }
    }
}
