using System.Collections.Generic;
using System.Linq;
using WebApplication.Infractructure.Utilities;
using WebApplication.Model.Context;
using WebApplication.Model.ViewModels;
using WebApplication.Repository.Interfaces;

namespace WebApplication.Repository.Implements
{
    public class CMSNewsRepository : RepositoryBase<cms_News>, ICMSNewsRepository
    {
        public CMSNewsRepository(OnlineStoreMVCEntities context) : base(context)
        {
        }

        public IList<cms_News> GetCMSNews(int pageNumber, int pageSize, out int totalItems)
        {
            totalItems = dbSet.Count(x => x.Status != (int)Define.Status.Delete);

            return dbSet.Where(x => x.Status != (int)Define.Status.Delete)
                    .OrderByDescending(x => x.SortOrder).ThenByDescending(x => x.CreatedDate)
                    .Skip(pageSize * (pageNumber - 1)).Take(pageSize)
                    .Select(x => x).ToList();
        }

        private IList<cms_News> GetCMSNewsRecursive(int categoryId)
        {
            var childCategories = context.cms_Categories.Where(x => x.ParentId == categoryId);

            var news = new List<cms_News>();
            if (childCategories.Count() == 0)
            {
                return news;
            }

            foreach (var category in childCategories)
            {
                news.AddRange(dbSet.Include("cms_Categories").Include("share_Images")
                    .Where(x => x.CategoryId == category.Id && x.Status == (int)Define.Status.Active)
                    .Select(x => x));

                GetCMSNewsRecursive(category.Id);
            }

            return news;
        }

        public IList<cms_News> GetCMSNewsByCategoryId(int categoryId, int pageNumber, int pageSize, out int totalItems)
        {
            var news = dbSet.Include("cms_Categories").Include("share_Images")
                .Where(x => x.CategoryId == categoryId && x.Status == (int)Define.Status.Active)
                .Select(x => x).ToList();

            news.AddRange(GetCMSNewsRecursive(categoryId));
            totalItems = news.Count();

            return news.OrderByDescending(x => x.SortOrder).ThenByDescending(x => x.CreatedDate).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
        }

        public IList<cms_News> GetRecentCMSNews()
        {
            return dbSet.Include("cms_Categories").Include("share_Images").Where(x => x.Status == (int)Define.Status.Active)
                .OrderByDescending(x => x.CreatedDate)
                .Take(3)
                .Select(x => x).ToList();
        }

        public IList<cms_News> GetRelatedCMSNews(int id)
        {
            var news = dbSet.Find(id);
            return dbSet.Include("cms_Categories").Include("share_Images").Where(x => x.Status == (int)Define.Status.Active && x.CategoryId == news.CategoryId && x.Id != news.Id)
                .OrderByDescending(x => x.CreatedDate)
                .Take(3)
                .Select(x => x).ToList();
        }

        public IList<cms_News> GetCMSNewsForHomePage()
        {
            return dbSet.Include("cms_Categories").Include("share_Images").Where(x => x.Status == (int)Define.Status.Active && x.DisplayHomePage == true)
                .OrderByDescending(x => x.CreatedDate)
                .Take(3)
                .Select(x => x).ToList();
        }

        public cms_News GetCMSNews(int Id)
        {
            return dbSet.Include("cms_Categories").Include("share_Images").FirstOrDefault(x => x.Id == Id);
        }

        public bool Delete(int? newsId)
        {
            var news = Find(newsId);
            if (news != null)
            {
                news.Status = (int)Define.Status.Delete;
                Save();
                return true;
            }

            return false;
        }
    }
}
