using System.Collections.Generic;
using System.Linq;
using WebApplication.Infractructure.Utilities;
using WebApplication.Model.Context;
using WebApplication.Model.ViewModels;
using WebApplication.Repository.Interfaces;

namespace WebApplication.Repository.Implements
{
    public class CMSCategoryRepository : RepositoryBase<CMSCategory>, ICMSCategoryRepository
    {
        public CMSCategoryRepository(OnlineStoreMVCEntities context)
           : base(context)
        {
        }

        public IList<CMSCategory> GetCMSCategories(int pageNumber, int pageSize, out int totalItems)
        {
            totalItems = dbSet.Count(x => x.Status != (int)Define.Status.Delete);

            return dbSet.Where(x => x.Status != (int)Define.Status.Delete)
                    .OrderBy(x => x.ParentId).ThenBy(x => x.SortOrder)
                    .Skip(pageSize * (pageNumber - 1)).Take(pageSize)
                    .Select(x => x).ToList();
        }

        public IList<CMSCategory> GetCMSCategoriesByParentId(int? parentId)
        {
            return dbSet.Where(x => x.ParentId == parentId).ToList();
        }
    }
}
