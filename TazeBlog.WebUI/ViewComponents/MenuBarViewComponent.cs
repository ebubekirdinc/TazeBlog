using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TazeBlog.Business.Abstract;
using TazeBlog.Entities.Concrete;

namespace TazeBlog.WebUI.ViewComponents
{
    public class MenuBarViewComponent : ViewComponent
    {
        private ICategoryService _categoryService;
        public MenuBarViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IViewComponentResult Invoke()
        {
            List<Category> categories = _categoryService.GetAll();
            return View(categories);
        }
    }
}
