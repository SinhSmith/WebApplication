using OnlineStore.Model.MessageModel;
using System;
using System.Collections.Generic;
using WebApplication.Infractructure.Helpers;
using WebApplication.Infractructure.Utilities;
using WebApplication.Model.Context;
using WebApplication.Model.ViewModels;

namespace WebApplication.Model.Mappers
{
    public static class CategoryMapper
    {
        public static SummaryCategoryViewModel ConvertToIndexCategoryView(ecom_Categories category)
        {
            var categoryView = new SummaryCategoryViewModel()
            {
                Id = category.Id,
                Name = category.Name,
                SortOrder = category.SortOrder,
                Status = EnumHelper.GetDescriptionFromEnum((Define.Status)category.Status)
            };

            return categoryView;
        }

        public static IList<SummaryCategoryViewModel> ConvertToIndexCategoryViews(IEnumerable<ecom_Categories> categories)
        {
            var listCategories = new List<SummaryCategoryViewModel>();
            foreach (var category in categories)
            {
                listCategories.Add(ConvertToIndexCategoryView(category));
            }

            return listCategories;
        }

        public static DetailCategoryViewModel ConvertToDetailCategoryViewModel(ecom_Categories category, string parentName, system_Profiles createBy, system_Profiles modifiedBy)
        {
            DetailCategoryViewModel detailCategory = new DetailCategoryViewModel()
            {
                Id = category.Id,
                Name = category.Name,
                ParentCategory = parentName,
                Description = category.Description,
                Url = category.Url,
                SortOrder = category.SortOrder,
                Status = EnumHelper.GetDescriptionFromEnum((Define.Status)category.Status),
                CreatedBy = createBy != null ? createBy.UserName : "",
                CreatedDate = string.Format("{0:yyyy-MM-dd}", category.CreatedDate),
                ModifiedBy = modifiedBy != null ? createBy.UserName : "",
                ModifiedDate = string.Format("{0:yyyy-MM-dd}", category.ModifiedDate)
            };

            return detailCategory;
        }

        public static ecom_Categories ConvertToCategoryModel(this CreateCategoryPostRequest viewModel)
        {
            var category = new ecom_Categories()
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Description = viewModel.Description,
                Url = viewModel.Url,
                SortOrder = viewModel.SortOrder,
                ParentId = viewModel.ParentId,
                Status = viewModel.Status != null ? (int)viewModel.Status : (int)Define.Status.Deactive,
                CreatedBy = null,
                CreatedDate = DateTime.Now,
                ModifiedBy = null,
                ModifiedDate = null
            };

            return category;
        }

        public static CategoryViewModel ConvertToCategoryViewModel(ecom_Categories category)
        {
            CategoryViewModel viewModel = new CategoryViewModel()
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                Url = category.Url,
                SortOrder = category.SortOrder,
                ParentId = category.ParentId,
                Status = category.Status
            };

            return viewModel;
        }
    }
}
