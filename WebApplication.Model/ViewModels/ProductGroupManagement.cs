using System;
using System.ComponentModel;

namespace WebApplication.Model.ViewModels
{
    public class CreateProductGroupPostRequest
    {
        public int Id { get; set; }
        [DisplayName("TÊN NHÓM SẢN PHẨM")]
        public string Name { get; set; }
        [DisplayName("MÔ TẢ")]
        public string Description { get; set; }
        [DisplayName("TRẠNG THÁI")]
        public Nullable<int> Status { get; set; }
    }
}
