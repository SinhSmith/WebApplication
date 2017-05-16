using PagedList;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication.Infractructure.Utilities;
using WebApplication.Model.ViewModels;
using WebApplication.Service.Implements;
using WebApplication.Service.Interfaces;

namespace WebApplication.Areas.Admin.Controllers
{
    public class CMSNewsController : BaseManagementController
    {
        private ICMSNewsService _cmsNewsService;
        private ICMSCategoryService _cmsCategoryService;
        private IImageService _imageService;
        public CMSNewsController(ICMSNewsService cmsNewsService, ICMSCategoryService cmsCategoryService, IImageService imageService)
        {
            _cmsNewsService = cmsNewsService;
            _cmsCategoryService = cmsCategoryService;
            _imageService = imageService;
        }

        [NonAction]
        protected virtual List<SelectListItem> PrepareAllCategoriesModel(int selectedItemId = 0)
        {
            var availableCategories = new List<SelectListItem>();
            int totalItems = 0;
            var categories = _cmsCategoryService.GetCMSCategories(1, int.MaxValue, out totalItems);
            foreach (var c in categories)
            {
                if (c.Id != selectedItemId)
                {
                    availableCategories.Add(new SelectListItem
                    {
                        Text = CMSCategoryExtensions.GetFormattedBreadCrumb(c, categories),
                        Value = c.Id.ToString()
                    });
                }
            }

            return availableCategories;
        }

        public ActionResult Index(string keyword, int page = 1)
        {
            int totalItems = 0;
            var categories = _cmsNewsService.GetCMSNews(page, Define.PAGE_SIZE, out totalItems);

            IPagedList<CMSNewsViewModel> pageNews = new StaticPagedList<CMSNewsViewModel>(categories, page, Define.PAGE_SIZE, totalItems);
            return View(pageNews);
        }

        public ActionResult Create()
        {
            ViewBag.AvailableCategories = PrepareAllCategoriesModel();
            return View();
        }

        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CMSNewsViewModel model, HttpPostedFileBase uploadFile)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (uploadFile != null && uploadFile.ContentLength > 0)
                    {
                        var imageId = UploadImage(_imageService, uploadFile);
                        model.CoverImageId = imageId;
                    }

                    _cmsNewsService.AddCMSNews(model);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }

            ViewBag.AvailableCategories = PrepareAllCategoriesModel();
            return View(model);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var news = _cmsNewsService.GetCMSNewsById(id);
            if (news == null)
            {
                return HttpNotFound();
            }

            ViewBag.AvailableCategories = PrepareAllCategoriesModel(id.Value);
            PopulateStatusDropDownList((Define.Status)news.Status);
            return View(news);
        }

        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CMSNewsViewModel model, HttpPostedFileBase uploadFile)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (uploadFile != null && uploadFile.ContentLength > 0)
                    {
                        var imageId = UploadImage(_imageService, uploadFile);
                        model.CoverImageId = imageId;
                    }

                    _cmsNewsService.EditCMSNews(model);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }

            ViewBag.AvailableCategories = PrepareAllCategoriesModel(model.Id);
            PopulateStatusDropDownList((Define.Status)model.Status);
            return View(model);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                _cmsNewsService.DeleteCMSNews(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View();
        }
    }
}