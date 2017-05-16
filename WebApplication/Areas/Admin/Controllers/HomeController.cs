using System.Web.Mvc;

namespace WebApplication.Areas.Admin.Controllers
{
    public class HomeController : BaseManagementController
    {
        public HomeController()
        {
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}