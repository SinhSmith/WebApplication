using System.Collections.Generic;
using WebApplication.Infractructure.Helpers;
using WebApplication.Infractructure.Utilities;
using WebApplication.Model.Context;
using WebApplication.Model.ViewModels;

namespace WebApplication.Model.Mappers
{
    public static class BrandMapper
    {
        public static DetailsBrandManagementView ConvertToDetailsBrandView(ecom_Brands brand, string createBy, string modifiredBy)
        {
            DetailsBrandManagementView returnView = new DetailsBrandManagementView()
            {
                Id = brand.Id,
                Name = brand.Name,
                Status = EnumHelper.GetDescriptionFromEnum((Define.Status)brand.Status),
                Description = brand.Description,
                CreatedBy = createBy,
                CreatedDate = string.Format("{0:yyyy-MM-dd}", brand.CreatedDate),
                ModifiedBy = modifiredBy,
                ModifiedDate = string.Format("{0:yyyy-MM-dd}", brand.ModifiedDate)
            };

            return returnView;
        }
        public static ecom_Brands ConvertToBrandModel(CreateBrandPostRequest brandRequest)
        {
            var brand = new ecom_Brands()
            {
                Id = brandRequest.Id,
                Name = brandRequest.Name,
                Status = brandRequest.Status,
                Description = brandRequest.Description
            };

            return brand;
        }
        public static EditBrandManagementGetResponse ConvertToEditBrandManagementGetResponse(ecom_Brands brand)
        {
            var returnModel = new EditBrandManagementGetResponse()
            {
                Id = brand.Id,
                Name = brand.Name,
                Status = (int)brand.Status,
                Description = brand.Description
            };

            return returnModel;
        }
        public static ecom_Brands ConvertToBrandModel(EditBrandManagementPostRequest brandView)
        {
            var returnModel = new ecom_Brands()
            {
                Id = brandView.Id,
                Name = brandView.Name,
                Status = brandView.Status,
                Description = brandView.Description
            };

            return returnModel;
        }
        public static BrandSummaryView ConvertToBrandSummaryView(ecom_Brands brand)
        {
            var brandSummaryView = new BrandSummaryView()
            {
                Id = brand.Id,
                Name = brand.Name
            };

            return brandSummaryView;
        }
        public static IEnumerable<BrandSummaryView> ConvertToBrandSummaryViews(IEnumerable<ecom_Brands> brands)
        {
            var brandSummaryViews = new List<BrandSummaryView>();
            foreach (var brand in brands)
            {
                brandSummaryViews.Add(ConvertToBrandSummaryView(brand));
            }

            return brandSummaryViews;
        }
    }
}
