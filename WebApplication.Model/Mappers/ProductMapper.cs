using System;
using System.Collections.Generic;
using WebApplication.Infractructure.Utilities;
using WebApplication.Model.Context;
using WebApplication.Model.ViewModels;

namespace WebApplication.Model.Mappers
{
    public static class ProductMapper
    {
        public static ProductFullView ConvertToProductFullView(ecom_Products product)
        {
            var productFullView = new ProductFullView()
            {
                Id = product.Id,
                ProductCode = product.ProductCode,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                Unit = product.Unit,
                BrandId = product.BrandId,
                CoverImageId = product.CoverImageId,
                Description = product.Description,
                Description2 = product.Description2,
                Specification = product.Specification,
                TotalView = product.TotalView,
                TotalBuy = product.TotalBuy,
                Tags = product.Tags,
                IsNewProduct = product.IsNewProduct,
                IsBestSellProduct = product.IsBestSellProduct,
                SortOrder = product.SortOrder,
                Status = product.Status,
                //CreatedBy = product.CreatedBy.to,
                //CreatedDate = product.CreatedDate,
                //ModifiedBy = product.ModifiedBy,
                //ModifiedDate = product.ModifiedDate
                //share_Images = product.share_Images.ConvertToImageProductViewModels()
            };

            return productFullView;
        }

        public static ImageProductViewModel ConvertToImageProductViewModel(share_Images image)
        {
            var imageViewModel = new ImageProductViewModel()
            {
                Id = image.Id,
                ImageName = image.ImageName,
                ImagePath = image.ImagePath,
                IsActive = image.Status == (int)Define.Status.Active ? true : false
            };

            return imageViewModel;
        }

        public static IEnumerable<ImageProductViewModel> ConvertToImageProductViewModels(IEnumerable<share_Images> images)
        {
            var listImages = new List<ImageProductViewModel>();
            foreach (var image in images)
            {
                listImages.Add(ConvertToImageProductViewModel(image));
            }

            return listImages;
        }

        public static ProductSummaryView ConvertToProductSummaryView(ecom_Products product)
        {
            var productSummaryView = new ProductSummaryView()
            {
                Id = product.Id,
                Name = product.Name,
                BrandName = product.ecom_Brands != null ? product.ecom_Brands.Name : "",
                PriceFormatCurrency = String.Format(System.Globalization.CultureInfo.GetCultureInfo("vi-VN"), "{0:C0}", product.Price),
                Price = product.Price,
                //CoverImageUrl = product.CoverImageId != null ? product.CoverImageId.ImagePath : DisplayProductConstants.NoImagePath,
                IsNew = product.IsNewProduct,
                ShortDescription = product.Description
            };

            return productSummaryView;
        }

        public static IEnumerable<ProductSummaryView> ConvertToProductSummaryViews(IEnumerable<ecom_Products> products)
        {
            var productSummaryViews = new List<ProductSummaryView>();
            foreach (var product in products)
            {
                productSummaryViews.Add(ConvertToProductSummaryView(product));
            }

            return productSummaryViews;
        }
    }
}