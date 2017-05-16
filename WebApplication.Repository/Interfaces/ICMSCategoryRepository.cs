using System.Collections.Generic;
using WebApplication.Model.Context;

namespace WebApplication.Repository.Interfaces
{
    public interface ICMSCategoryRepository : IRepositoryBase<cms_Categories>
	{
        IList<cms_Categories> GetCMSCategories(string keyword, int pageNumber, int pageSize, out int totalItems);

        IList<cms_Categories> GetCMSCategoriesByParentId(int? parentId);
        bool Delete(int? categoryId);
    }
}
