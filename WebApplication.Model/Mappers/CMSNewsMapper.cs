using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication.Infractructure.Utilities;
using WebApplication.Model.Context;
using WebApplication.Model.ViewModels;

namespace WebApplication.Model.Mappers
{
    public class CMSNewsMapper
    {
        public static IList<CMSNewsViewModel> ConvertListCMSNewsToListCMSNewsViewModel(IList<cms_News> news)
        {
            return news.ToList().Select(x => new CMSNewsViewModel
            {
                Id = x.Id,
                CategoryId = x.CategoryId,
                CategoryTitle = x.cms_Categories.Title,
                CoverImageId = x.CoverImageId,
                CoverImageName = x.share_Images.ImageName,
                CoverImagePath = x.share_Images.ImagePath,
                Title = x.Title,
                SubTitle = x.SubTitle,
                ContentNews = x.ContentNews,
                Authors = x.Authors,
                Tags = x.Tags,
                DisplayHomePage = x.DisplayHomePage,
                TotalView = x.TotalView,
                Status = x.Status,
                SortOrder = x.SortOrder,
                CreatedDate = x.CreatedDate
            }).ToList();
        }

        public static CMSNewsViewModel ConvertCMSNewsToCMSNewsViewModel(cms_News news)
        {
            return new CMSNewsViewModel
            {
                Id = news.Id,
                CategoryId = news.CategoryId,
                CategoryTitle = news.cms_Categories.Title,
                CoverImageId = news.CoverImageId,
                CoverImageName = news.share_Images.ImageName,
                CoverImagePath = news.share_Images.ImagePath,
                Title = news.Title,
                SubTitle = news.SubTitle,
                ContentNews = news.ContentNews,
                Authors = news.Authors,
                Tags = news.Tags,
                DisplayHomePage = news.DisplayHomePage,
                TotalView = news.TotalView,
                Status = news.Status,
                SortOrder = news.SortOrder,
                CreatedDate = news.CreatedDate
            };
        }

        public static cms_News ConvertCMSNewsViewModelToCMSNews(CMSNewsViewModel viewModel)
        {
            return new cms_News
            {
                CategoryId = viewModel.CategoryId,
                CoverImageId = viewModel.CoverImageId,
                Title = viewModel.Title,
                SubTitle = viewModel.SubTitle,
                ContentNews = viewModel.ContentNews,
                Authors = viewModel.Authors,
                Tags = viewModel.Tags,
                TotalView = viewModel.TotalView,
                DisplayHomePage = viewModel.DisplayHomePage,
                Status = (int)Define.Status.Active,
                SortOrder = viewModel.SortOrder,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
        }
    }
}
