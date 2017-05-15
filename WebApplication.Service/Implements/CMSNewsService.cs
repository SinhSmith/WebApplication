using System;
using System.Collections.Generic;
using WebApplication.Model.Mappers;
using WebApplication.Model.ViewModels;
using WebApplication.Repository.Interfaces;
using WebApplication.Service.Interfaces;

namespace WebApplication.Service.Implements
{
    public class CMSNewsService : ICMSNewsService, IDisposable
    {
        ICMSNewsRepository _cmsNewsRepository;

        public CMSNewsService(ICMSNewsRepository cmsNewsRepository)
        {
            _cmsNewsRepository = cmsNewsRepository;
        }

        public IList<CMSNewsViewModel> GetCMSNews(int pageNumber, int pageSize, out int totalItems)
        {
            var news = _cmsNewsRepository.GetCMSNews(pageNumber, pageSize, out totalItems);
            return CMSNewsMapper.ConvertListCMSNewsToListCMSNewsViewModel(news);
        }

        public IList<CMSNewsViewModel> GetCMSNewsByCategoryId(int categoryId, int pageNumber, int pageSize, out int totalItems)
        {
            var news = _cmsNewsRepository.GetCMSNewsByCategoryId(categoryId, pageNumber, pageSize, out totalItems);
            return CMSNewsMapper.ConvertListCMSNewsToListCMSNewsViewModel(news);
        }

        public IList<CMSNewsViewModel> GetRecentCMSNews()
        {
            var news = _cmsNewsRepository.GetRecentCMSNews();
            return CMSNewsMapper.ConvertListCMSNewsToListCMSNewsViewModel(news);
        }

        public IList<CMSNewsViewModel> GetRelatedCMSNews(int id)
        {
            var news = _cmsNewsRepository.GetRelatedCMSNews(id);
            return CMSNewsMapper.ConvertListCMSNewsToListCMSNewsViewModel(news);
        }

        public IList<CMSNewsViewModel> GetCMSNewsForHomePage()
        {
            var news = _cmsNewsRepository.GetCMSNewsForHomePage();
            return CMSNewsMapper.ConvertListCMSNewsToListCMSNewsViewModel(news);
        }

        public bool AddCMSNews(CMSNewsViewModel viewModel)
        {
            try
            {
                var news = CMSNewsMapper.ConvertCMSNewsViewModelToCMSNews(viewModel);
                _cmsNewsRepository.Add(news);
                _cmsNewsRepository.Save();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EditCMSNews(CMSNewsViewModel viewModel)
        {
            try
            {
                var news = _cmsNewsRepository.Find(viewModel.Id);
                news.CategoryId = viewModel.CategoryId;
                news.CoverImageId = viewModel.CoverImageId;
                news.Title = viewModel.Title;
                news.SubTitle = viewModel.SubTitle;
                news.ContentNews = viewModel.ContentNews;
                news.Authors = viewModel.Authors;
                news.Tags = viewModel.Tags;
                news.TotalView = viewModel.TotalView;
                news.DisplayHomePage = viewModel.DisplayHomePage;
                news.SortOrder = viewModel.SortOrder;
                news.Status = viewModel.Status;
                news.ModifiedDate = DateTime.Now;
                _cmsNewsRepository.Save();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateCMSNewsCountView(int? newsId)
        {
            try
            {
                var news = _cmsNewsRepository.Find(newsId);
                news.TotalView++;
                _cmsNewsRepository.Save();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CMSNewsViewModel GetCMSNewsById(int? newsId)
        {
            if (newsId == null)
                return null;

            var news = _cmsNewsRepository.GetCMSNews(newsId.Value);
            return CMSNewsMapper.ConvertCMSNewsToCMSNewsViewModel(news);
        }

        public bool DeleteCMSNews(int id)
        {
            try
            {
                return _cmsNewsRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Dispose context
        /// <summary>
        /// The disposed
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _cmsNewsRepository.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
