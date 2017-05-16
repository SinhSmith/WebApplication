using System.Collections.Generic;
using System.ComponentModel;

namespace WebApplication.Infractructure.Utilities
{
    public class Define
    {
        public const int PAGE_SIZE = 10;
        public const int ID_PAGE_INTRODUCTION = 18;
        public enum SystemConfig
        {
            TotalVisitors
        }

        public enum Status
        {
            [Description("Ngưng hoạt động")]
            Deactive = 0,

            [Description("Đang hoạt động")]
            Active = 1,

            [Description("Xóa")]
            Delete = 2
        }

        public enum MenuEnum
        {
            [Description("Admin")]
            Admin = 1,

            [Description("User")]
            User = 2,
        }

        public enum BannerTypes
        {
            [Description("Banner 1 - Slide")]
            Banner1 = 1,

            [Description("Banner 2 - Mùa Xuân")]
            SpringSeason = 2,

            [Description("Banner 2 - Mùa Hạ")]
            SummerSeason = 3,

            [Description("Banner 2 - Mùa Thu")]
            AutumnSeason = 4,

            [Description("Banner 2 - Mùa Đông")]
            WinterSeason = 5,

            [Description("Popup")]
            Popup = 10
        }

        public const string ImageSavePath = "/Uploads/";

        #region Products
        public static class DisplayProductConstants
        {
            public const int NumberProductPerPage = 10;
            public const string BackGroundImage = @"/Content/Images/background_image.png";
            public const string NoImagePath = @"/Content/Images/no-image.png";
            public const string LargeProductImageFolderPath = @"/Content/Images/ProductImages/LargeImages/";
            public const string SmallProductImageFolderPath = @"/Content/Images/ProductImages/SmallImages/";
        }

        public enum ProductsSortBy
        {
            [Description("Price: from high to low")]
            PriceHighToLow = 1,
            [Description("Price: from low to high")]
            PriceLowToHigh = 2,
            [Description("Name: from A to Z")]
            ProductNameAToZ = 3,
            [Description("Name: from Z to A")]
            ProductNameZToA = 4
        }

        public enum SearchType
        {
            [Description("Tất cả các sản phẩm")]
            AllProduct = 1,
            //[Description("Tìm kiếm theo từ khóa")]
            //SearchString = 2,
            [Description("Sản phẩm mới")]
            NewProducts = 3,
            [Description("Sản phẩm bán chạy nhất")]
            BestSellProducts = 4
        }

        public enum MainProductCategory
        {
            [Description("Bánh")]
            BakeryProducts = 8,
            [Description("Vật Dụng Nhà Bếp")]
            KitchenTools = 9
        }

        public enum OrderStatus
        {
            [Description("Chưa giao")]
            NotDeliver = 1,

            [Description("Đã giao")]
            Delivered = 2,

            [Description("Hủy")]
            Cancel = 3
        }
        #endregion

        #region Orders
        public enum OrderPriorityEnum
        {
            High,
            Medium,
            Low
        }

        public class OrderPriority
        {
            public string Name { get; set; }
            public int Value { get; set; }

            public OrderPriority(string Name, int Value)
            {
                this.Name = Name;
                this.Value = Value;
            }

        }

        public static class OrderPriorityHelper
        {
            public static IEnumerable<OrderPriority> getListOrderPriority()
            {
                var reVal = new List<OrderPriority>(){
                new OrderPriority("High",(int)OrderPriorityEnum.High),
                new OrderPriority("Medium",(int)OrderPriorityEnum.Medium),
                new OrderPriority("Low",(int)OrderPriorityEnum.Low)
            };

                return reVal;
            }

            public static string GetOrderPriorityName(int? order)
            {
                switch (order)
                {
                    case (int)OrderPriorityEnum.High: return "High";
                    case (int)OrderPriorityEnum.Medium: return "Medium";
                    case (int)OrderPriorityEnum.Low: return "Low";
                    default: return "";
                }
            }
        }
        #endregion
    }
}
