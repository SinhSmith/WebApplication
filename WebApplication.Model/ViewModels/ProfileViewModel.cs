using System;

namespace WebApplication.Model.ViewModels
{
	public class ProfileViewModel
	{
		public Guid UserId { get; set; }
		public string UserName { get; set; }
		public string Emaill { get; set; }
		public string Password { get; set; }
		public string Phone { get; set; }
		public string Address { get; set; }
		public int? Status { get; set; }
	}
}
