using System;
using System.Collections.Generic;
using WebApplication.Model.Mappers;
using WebApplication.Model.ViewModels;
using WebApplication.Repository.Interfaces;
using WebApplication.Service.Interfaces;

namespace WebApplication.Service.Implements
{
    public class CMSCategoryService : ICMSCategoryService, IDisposable
    {
        ICMSCategoryRepository _cmsCategoryRepository;

        public CMSCategoryService(ICMSCategoryRepository cmsCategoryRepository)
        {
            _cmsCategoryRepository = cmsCategoryRepository;
        }

        public IList<CMSCategoryViewModel> GetCMSCategories(string keyword, int pageNumber, int pageSize, out int totalItems)
        {
            var categories = _cmsCategoryRepository.GetCMSCategories(keyword, pageNumber, pageSize, out totalItems);
            return CMSCategoryMapper.ConvertListCMSCategoryToListCMSCategoryViewModel(categories);
        }

        public bool AddCMSCategory(CMSCategoryViewModel viewModel)
        {
            try
            {
                var category = CMSCategoryMapper.ConvertCMSCategoryViewModelToCMSCategory(viewModel);
                _cmsCategoryRepository.Add(category);
                _cmsCategoryRepository.Save();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EditCMSCategory(CMSCategoryViewModel viewModel)
        {
            try
            {
                var category = _cmsCategoryRepository.Find(viewModel.Id);
                if (category != null)
                {
                    category.ParentId = viewModel.ParentId;
                    category.Title = viewModel.Title;
                    category.Description = viewModel.Description;
                    category.Url = viewModel.Url;
                    category.SortOrder = viewModel.SortOrder;
                    category.Status = viewModel.Status;
                    category.ModifiedDate = DateTime.Now;
                    _cmsCategoryRepository.Save();

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CMSCategoryViewModel GetCMSCategoryById(int? categoryId)
        {
            if (categoryId == null)
                return null;

            var category = _cmsCategoryRepository.Find(categoryId);
            if (category != null)
            {
                return CMSCategoryMapper.ConvertCMSCategoryToCMSCategoryViewModel(category);
            }

            return null;
        }

        public IList<CMSCategoryViewModel> GetChildCategoriesByParentId(int? parentId)
        {
            if (parentId == null)
                return null;

            var categories = _cmsCategoryRepository.GetCMSCategoriesByParentId(parentId);
            if (categories.Count == 0)
            {
                var category = _cmsCategoryRepository.Find(parentId);
                categories = _cmsCategoryRepository.GetCMSCategoriesByParentId(category.ParentId);

                return CMSCategoryMapper.ConvertListCMSCategoryToListCMSCategoryViewModel(categories);
            }

            return CMSCategoryMapper.ConvertListCMSCategoryToListCMSCategoryViewModel(categories);
        }

        public bool DeleteCMSCategory(int id)
        {
            try
            {
                return _cmsCategoryRepository.Delete(id);
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
                    _cmsCategoryRepository.Dispose();
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
