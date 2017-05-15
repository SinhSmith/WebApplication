using System.Collections.Generic;
using System.Linq;
using WebApplication.Infractructure.Utilities;
using WebApplication.Model.Context;
using WebApplication.Repository.Implements;
using WebApplication.Repository.Interfaces;

namespace WebApplication.Repository.Implements
{
    public class CategoryRepository : RepositoryBase<ecom_Categories>, ICategoryRepository
    {
        public CategoryRepository(OnlineStoreMVCEntities context) : base(context)
        {
        }

        public IEnumerable<ecom_Categories> GetAllCategories()
        {
            return dbSet.ToList();
        }

        public IEnumerable<ecom_Categories> GetAllCategoriesWithoutDelete()
        {
            return dbSet.Where(c => c.Status != (int)Define.Status.Delete).ToList();
        }

        public IEnumerable<ecom_Categories> GetAllActiveCategories()
        {
            return dbSet.Where(c => c.Status == (int)Define.Status.Active).ToList();
        }

        public ecom_Categories GetCategoryById(int id)
        {
            return dbSet.Where(c => c.Id == id && c.Status != (int)Define.Status.Delete).FirstOrDefault();
        }

        public IEnumerable<ecom_Categories> GetChildrenByParentCategoryId(int? parentId)
        {
            return dbSet.Where(c => c.ParentId == parentId && c.Status == (int)Define.Status.Active).ToList();
        }

        public IEnumerable<ecom_Categories> GetAllActiveCategory()
        {
            return dbSet.Where(c => c.Status == (int)Define.Status.Active).ToList();
        }

        public IEnumerable<ecom_Categories> GetTopCategories()
        {
            return dbSet.Where(c => c.Status == (int)Define.Status.Active && c.ParentId == null).Take(8).ToList();
        }
    }
}
