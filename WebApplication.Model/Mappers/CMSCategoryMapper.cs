using AutoMapper;
using System;
using System.Collections.Generic;
using WebApplication.Infractructure.Utilities;
using WebApplication.Model.Context;
using WebApplication.Model.ViewModels;

namespace WebApplication.Model.Mappers
{
    public class CMSCategoryMapper
    {
        public static IList<CMSCategoryViewModel> ConvertListCMSCategoryToListCMSCategoryViewModel(IList<cms_Categories> categories)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<cms_Categories, CMSCategoryViewModel>());
            var mapper = config.CreateMapper();
            var result = mapper.Map<IList<CMSCategoryViewModel>>(categories);

            return result;
        }

        public static CMSCategoryViewModel ConvertCMSCategoryToCMSCategoryViewModel(cms_Categories category)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<cms_Categories, CMSCategoryViewModel>());
            var mapper = config.CreateMapper();
            var result = mapper.Map<CMSCategoryViewModel>(category);

            return result;
        }

        public static cms_Categories ConvertCMSCategoryViewModelToCMSCategory(CMSCategoryViewModel viewModel)
        {
            return new cms_Categories
            {
                ParentId = viewModel.ParentId,
                Title = viewModel.Title,
                Description = viewModel.Description,
                Url = viewModel.Url,
                SortOrder = viewModel.SortOrder,
                Status = (int)Define.Status.Active,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
        }
    }
}
