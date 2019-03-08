using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TazeBlog.Business.Abstract;
using TazeBlog.Entities.ComplexTypes;

namespace TazeBlog.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IArticleService _articleService;
        private ICategoryService _categoryService;
        public HomeController(IArticleService articleService, ICategoryService categoryService)
        {
            _categoryService = categoryService;
            _articleService = articleService;
        }
        public ActionResult PartialMenuBar()
        {
            var menuModel = _categoryService.GetAll();
            return PartialView("_MenuBar", menuModel);
        }
        public IActionResult Index()
        {
            var ArticleModel = _articleService.GetAll().Select(x => new ArticleCategory
            {
                Categories = new List<Entities.Concrete.Category>
                {
                    _categoryService.GetById(x.CategoryId)
                },
                Name = x.Name,
                Content = x.Content,
                CreatedOn = x.CreatedOn,
                Id = x.Id,
                Permalink = x.Permalink
            });
            return View(ArticleModel);
        }
    }
}
