using PagedList;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using WebApplication.Infractructure.Utilities;
using WebApplication.Model.ViewModels;
using WebApplication.Service.Implements;
using WebApplication.Service.Interfaces;

namespace WebApplication.Areas.Admin.Controllers
{
    public class CMSCategoryController : BaseManagementController
    {
        private ICMSCategoryService _cmsCategoryService;
        public CMSCategoryController(ICMSCategoryService cmsCategoryService)
        {
            _cmsCategoryService = cmsCategoryService;
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
            var categories = _cmsCategoryService.GetCMSCategories(page, Define.PAGE_SIZE, out totalItems);

            var availableCategories = new List<CMSCategoryViewModel>();
            foreach (var item in categories)
            {
                item.Title = CMSCategoryExtensions.GetFormattedBreadCrumb(item, _cmsCategoryService);
                availableCategories.Add(item);
            }

            IPagedList<CMSCategoryViewModel> pageCategories = new StaticPagedList<CMSCategoryViewModel>(availableCategories, page, Define.PAGE_SIZE, totalItems);
            return View(pageCategories);
        }

        public ActionResult Create()
        {
            ViewBag.AvailableCategories = PrepareAllCategoriesModel();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CMSCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _cmsCategoryService.AddCMSCategory(model);

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
            var category = _cmsCategoryService.GetCMSCategoryById(id);
            if (category == null)
            {
                return HttpNotFound();
            }

            ViewBag.AvailableCategories = PrepareAllCategoriesModel(id.Value);
            PopulateStatusDropDownList((Define.Status)category.Status);
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CMSCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _cmsCategoryService.EditCMSCategory(model);

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
            _cmsCategoryService.DeleteCMSCategory(id);
            return RedirectToAction("Index");
        }
    }
}