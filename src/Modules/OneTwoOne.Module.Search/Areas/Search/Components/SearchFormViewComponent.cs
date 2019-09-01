using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OneTwoOne.Infrastructure.Data;
using OneTwoOne.Infrastructure.Web;
using OneTwoOne.Module.Catalog.Models;
using OneTwoOne.Module.Search.Areas.Search.ViewModels;

namespace OneTwoOne.Module.Search.Areas.Search.Components
{
    public class SearchFormViewComponent : ViewComponent
    {
        private IRepository<Category> _categoryRepository;

        public SearchFormViewComponent(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            var model = new SearchForm();
            model.AvailableCategories = _categoryRepository
                .Query()
                .Where(x => x.IsPublished && x.Parent == null)
                .Select(x => new SelectListItem
                {
                    Value = x.Slug,
                    Text = x.Name
                }).ToList();

            model.Query = Request.Query["query"];
            model.Category = Request.Query["category"];

            return View(this.GetViewPath(), model);
        }
    }
}
