using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication.Model.ViewModels;
using WebApplication.Service.Interfaces;

namespace WebApplication.Service.Implements
{
    public class CMSCategoryExtensions
    {
        public static string GetFormattedBreadCrumb(CMSCategoryViewModel category, IList<CMSCategoryViewModel> allCategories, string separator = ">>")
        {
            string result = string.Empty;

            var breadcrumb = GetCategoryBreadCrumb(category, allCategories);
            for (int i = 0; i <= breadcrumb.Count - 1; i++)
            {
                var categoryName = breadcrumb[i].Title;
                result = String.IsNullOrEmpty(result)
                    ? categoryName
                    : string.Format("{0} {1} {2}", result, separator, categoryName);
            }

            return result;
        }

        public static IList<CMSCategoryViewModel> GetCategoryBreadCrumb(CMSCategoryViewModel category, IList<CMSCategoryViewModel> allCategories)
        {
            if (category == null)
                throw new ArgumentNullException("category");

            var result = new List<CMSCategoryViewModel>();

            //used to prevent circular references
            var alreadyProcessedCategoryIds = new List<int>();

            while (category != null && //not null
                !alreadyProcessedCategoryIds.Contains(category.Id)) //prevent circular references
            {
                result.Add(category);

                alreadyProcessedCategoryIds.Add(category.Id);

                category = (from c in allCategories
                            where c.Id == category.ParentId
                            select c).FirstOrDefault();
            }
            result.Reverse();
            return result;
        }

        public static string GetFormattedBreadCrumb(CMSCategoryViewModel category, ICMSCategoryService categoryService, string separator = ">>")
        {
            string result = string.Empty;

            var breadcrumb = GetCategoryBreadCrumb(category, categoryService);
            for (int i = 0; i <= breadcrumb.Count - 1; i++)
            {
                var categoryName = breadcrumb[i].Title;
                result = String.IsNullOrEmpty(result)
                    ? categoryName
                    : string.Format("{0} {1} {2}", result, separator, categoryName);
            }

            return result;
        }

        public static IList<CMSCategoryViewModel> GetCategoryBreadCrumb(CMSCategoryViewModel category, ICMSCategoryService categoryService)
        {
            if (category == null)
                throw new ArgumentNullException("category");

            var result = new List<CMSCategoryViewModel>();

            //used to prevent circular references
            var alreadyProcessedCategoryIds = new List<int>();

            while (category != null && //not null
                !alreadyProcessedCategoryIds.Contains(category.Id)) //prevent circular references
            {
                result.Add(category);

                alreadyProcessedCategoryIds.Add(category.Id);

                category = categoryService.GetCMSCategoryById(category.ParentId);
            }
            result.Reverse();
            return result;
        }
    }
}
