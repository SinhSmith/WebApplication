using System.Collections.Generic;
using WebApplication.Model.Context;

namespace WebApplication.Repository.Interfaces
{
    public interface ProductGroupRepository : IRepositoryBase<ecom_ProductGroups>
	{
        IList<ecom_ProductGroups> GetAllAvailableGroups();
    }
}
