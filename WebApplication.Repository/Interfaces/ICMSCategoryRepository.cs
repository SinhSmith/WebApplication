using System.Collections.Generic;
using WebApplication.Model.Context;
using WebApplication.Model.ViewModels;

namespace WebApplication.Repository.Interfaces
{
	public interface ICMSCategoryRepository : IRepositoryBase<CMSCategory>
	{
        IList<CMSCategory> GetCMSCategories(int pageNumber, int pageSize, out int totalItems);

        IList<CMSCategory> GetCMSCategoriesByParentId(int? parentId);
    }
}
