using System.Collections.Generic;
using System.Linq;
using WebApplication.Infractructure.Utilities;
using WebApplication.Model.Context;
using WebApplication.Repository.Interfaces;

namespace WebApplication.Repository.Implements
{
    public class CMSCategoryRepository : RepositoryBase<cms_Categories>, ICMSCategoryRepository
    {
        public CMSCategoryRepository(OnlineStoreMVCEntities context) : base(context)
        {
        }

        public IList<cms_Categories> GetCMSCategories(int pageNumber, int pageSize, out int totalItems)
        {
            totalItems = dbSet.Count(x => x.Status != (int)Define.Status.Delete);

            return dbSet.Where(x => x.Status != (int)Define.Status.Delete)
                    .OrderBy(x => x.ParentId).ThenBy(x => x.SortOrder)
                    .Skip(pageSize * (pageNumber - 1)).Take(pageSize)
                    .Select(x => x).ToList();
        }

        public IList<cms_Categories> GetCMSCategoriesByParentId(int? parentId)
        {
            return dbSet.Where(x => x.ParentId == parentId).ToList();
        }

        public bool Delete(int? categoryId)
        {
            var category = Find(categoryId);
            if (category != null)
            {
                category.Status = (int)Define.Status.Delete;
                Save();
                return true;
            }

            return false;
        }
    }
}
