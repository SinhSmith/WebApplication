using System;
using System.Collections.Generic;
using WebApplication.Model.ViewModels;

namespace WebApplication.Service.Interfaces
{
    public interface ICMSCategoryService : IDisposable
    {
        IList<CMSCategoryViewModel> GetCMSCategories(string keyword, int pageNumber, int pageSize, out int totalItems);

        bool AddCMSCategory(CMSCategoryViewModel viewModel);

        bool EditCMSCategory(CMSCategoryViewModel viewModel);

        CMSCategoryViewModel GetCMSCategoryById(int? categoryId);

        IList<CMSCategoryViewModel> GetChildCategoriesByParentId(int? parentId);

        bool DeleteCMSCategory(int id);
    }
}
