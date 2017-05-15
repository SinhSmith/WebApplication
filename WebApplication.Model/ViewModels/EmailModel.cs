using System.ComponentModel.DataAnnotations;

namespace WebApplication.Model.ViewModels
{
    public class EmailFormModel
    {
        [Required, Display(Name = "Tên")]
        public string Name { get; set; }
        [Required, Display(Name = "Email"), EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
