using System;
using System.ComponentModel;

namespace WebApplication.Model.ViewModels
{
    public class EditProductGroupManagementPostRequest
    {
        public int Id { get; set; }
        [DisplayName("TÊN NHÓM SẢN PHẨM")]
        public string Name { get; set; }
        [DisplayName("TRẠNG THÁI")]
        public Nullable<int> Status { get; set; }
        [DisplayName("THÔNG TIN VỀ NHÓM SẢN PHẨM")]
        public string Description { get; set; }
    }
    public class ProductGroupViewModel
    {
        public int Id { get; set; }
        [DisplayName("TÊN NHÓM SẢN PHẨM")]
        public string Name { get; set; }
        [DisplayName("TRẠNG THÁI")]
        public Nullable<int> Status { get; set; }
        [DisplayName("THÔNG TIN VỀ NHÓM SẢN PHẨM")]
        public string Description { get; set; }
    }
}
