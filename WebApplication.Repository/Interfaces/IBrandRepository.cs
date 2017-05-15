using System.Collections.Generic;
using WebApplication.Model.Context;

namespace WebApplication.Repository.Interfaces
{
    public interface IBrandRepository : IRepositoryBase<ecom_Brands>
	{
        IList<ecom_Brands> GetAllAvailableBrands();
    }
}
