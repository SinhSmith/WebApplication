using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication.Infractructure.Utilities;
using WebApplication.Model.Context;
using WebApplication.Model.ViewModels;

namespace WebApplication.Model.Mappers
{
    public class ImageMapper
    {
        public static share_Images ConvertImageProductViewModelToImage(ImageProductViewModel viewModel)
        {
            return new share_Images
            {
                ImageName = viewModel.ImageName,
                ImagePath = viewModel.ImagePath,
                Status = (int)Define.Status.Active,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
        }
    }
}
