using WebApplication.Model.Context;
using WebApplication.Model.ViewModels;

namespace WebApplication.Model.Mappers
{
    public static class ProductGroupMapper
    {
        public static ecom_ProductGroups ConvertToProductGroupModel(CreateProductGroupPostRequest productGroupRequest)
        {
            var group = new ecom_ProductGroups()
            {
                Id = productGroupRequest.Id,
                Name = productGroupRequest.Name,
                Status = productGroupRequest.Status,
                Description = productGroupRequest.Description
            };

            return group;
        }

        public static ProductGroupViewModel ConvertToProductGroupViewModel(ecom_ProductGroups group)
        {
            var returnModel = new ProductGroupViewModel()
            {
                Id = group.Id,
                Name = group.Name,
                Status = (int)group.Status,
                Description = group.Description
            };

            return returnModel;
        }

        public static ecom_ProductGroups ConvertToProductGroupViewModel(EditProductGroupManagementPostRequest groupView)
        {
            var returnModel = new ecom_ProductGroups()
            {
                Id = groupView.Id,
                Name = groupView.Name,
                Status = groupView.Status,
                Description = groupView.Description
            };

            return returnModel;
        }
    }
}
