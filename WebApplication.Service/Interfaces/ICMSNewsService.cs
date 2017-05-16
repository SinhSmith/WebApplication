using System;
using System.Collections.Generic;
using WebApplication.Model.ViewModels;

namespace WebApplication.Service.Interfaces
{
    public interface ICMSNewsService : IDisposable
    {
        IList<CMSNewsViewModel> GetCMSNews(int pageNumber, int pageSize, out int totalItems);
        IList<CMSNewsViewModel> GetCMSNewsByCategoryId(int categoryId, int pageNumber, int pageSize, out int totalItems);
        IList<CMSNewsViewModel> GetRecentCMSNews();
        IList<CMSNewsViewModel> GetRelatedCMSNews(int id);
        IList<CMSNewsViewModel> GetCMSNewsForHomePage();
        bool AddCMSNews(CMSNewsViewModel viewModel);
        bool EditCMSNews(CMSNewsViewModel viewModel);
        bool UpdateCMSNewsCountView(int? newsId);
        CMSNewsViewModel GetCMSNewsById(int? newsId);
        bool DeleteCMSNews(int id);
    }
}
