using System.Collections.Generic;
using WebApplication.Model.Context;

namespace WebApplication.Repository.Interfaces
{
    public interface ICategoryRepository : IRepositoryBase<ecom_Categories>
    {
        IEnumerable<ecom_Categories> GetAllCategories();
        IEnumerable<ecom_Categories> GetAllCategoriesWithoutDelete();
        IEnumerable<ecom_Categories> GetAllActiveCategories();
        ecom_Categories GetCategoryById(int id);
        IEnumerable<ecom_Categories> GetChildrenByParentCategoryId(int? parentId);
        IEnumerable<ecom_Categories> GetAllActiveCategory();
        IEnumerable<ecom_Categories> GetTopCategories();
    }
}
