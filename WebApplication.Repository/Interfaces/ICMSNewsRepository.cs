using System.Collections.Generic;
using WebApplication.Model.Context;

namespace WebApplication.Repository.Interfaces
{
    public interface ICMSNewsRepository : IRepositoryBase<cms_News>
    {
        IList<cms_News> GetCMSNews(string keyword, int pageNumber, int pageSize, out int totalItems);
        IList<cms_News> GetCMSNewsByCategoryId(int categoryId, int pageNumber, int pageSize, out int totalItems);
        IList<cms_News> GetRecentCMSNews();
        IList<cms_News> GetRelatedCMSNews(int id);
        IList<cms_News> GetCMSNewsForHomePage();
        cms_News GetCMSNews(int Id);
        bool Delete(int? newsId);
    }
}
