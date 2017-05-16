using System;
using System.Collections.Generic;
using WebApplication.Model.Context;
using WebApplication.Model.Mappers;
using WebApplication.Model.ViewModels;
using WebApplication.Repository.Interfaces;
using WebApplication.Service.Interfaces;

namespace WebApplication.Service.Implements
{
    public class ImageService : IImageService, IDisposable
    {
        IImageRepository _imageRepository;

        public ImageService(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public int AddImage(ImageProductViewModel viewModel)
        {
            try
            {
                var image = ImageMapper.ConvertImageProductViewModelToImage(viewModel);
                _imageRepository.Add(image);
                _imageRepository.Save();

                return image.Id;
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
                    _imageRepository.Dispose();
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
