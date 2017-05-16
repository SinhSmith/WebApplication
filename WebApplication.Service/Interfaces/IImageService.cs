using System;
using System.Collections.Generic;
using WebApplication.Model.ViewModels;

namespace WebApplication.Service.Interfaces
{
    public interface IImageService : IDisposable
    {
        int AddImage(ImageProductViewModel viewModel);
    }
}
