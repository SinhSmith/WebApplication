using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Infractructure.Helpers;
using WebApplication.Infractructure.Utilities;
using WebApplication.Model.ViewModels;
using WebApplication.Service.Interfaces;

namespace WebApplication.Areas.Admin.Controllers
{
    public class BaseManagementController : Controller
    {
        public BaseManagementController()
        {
        }

        /// <summary>
        /// Get list options for Status dropdownlist and assign to Variable in ViewBag of view
        /// </summary>
        /// <param name="status"></param>
        protected virtual void PopulateStatusDropDownList(Define.Status status = Define.Status.Active)
        {
            IEnumerable<Define.Status> values = Enum.GetValues(typeof(Define.Status)).Cast<Define.Status>();
            IEnumerable<SelectListItem> items = from value in values
                                                where value != Define.Status.Delete
                                                select new SelectListItem
                                                {
                                                    Text = EnumHelper.GetDescriptionFromEnum((Define.Status)value),
                                                    Value = ((int)value).ToString(),
                                                    Selected = value == status,
                                                };

            ViewBag.Status = items;
        }

        protected int UploadImage(IImageService imageService, HttpPostedFileBase file)
        {
            var fileName = Path.GetFileName(file.FileName);
            string filePath = Define.ImageSavePath + Guid.NewGuid().ToString() + "/";

            if (!Directory.Exists(Server.MapPath(filePath)))
            {
                Directory.CreateDirectory(Server.MapPath(filePath));
            }

            var path = Path.Combine(Server.MapPath(filePath), fileName);
            file.SaveAs(path);

            var imageModel = new ImageProductViewModel
            {
                ImageName = file.FileName,
                ImagePath = Path.Combine(filePath, fileName)
            };
            return imageService.AddImage(imageModel);
        }

        #region Release resources

        /// <summary>
        /// Dispose database connection
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        #endregion
    }
}