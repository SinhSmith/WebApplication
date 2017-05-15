using System;
using System.ComponentModel;

namespace WebApplication.Model.ViewModels
{
    public class CreateBrandPostRequest
    {
        public int Id { get; set; }
        [DisplayName("TÊN THƯƠNG HIỆU")]
        public string Name { get; set; }
        [DisplayName("MÔ TẢ")]
        public string Description { get; set; }
        [DisplayName("TRẠNG THÁI")]
        public Nullable<int> Status { get; set; }
    }
}
