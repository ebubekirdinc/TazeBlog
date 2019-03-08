using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TazeBlog.Business.Abstract;
using TazeBlog.Entities.ComplexTypes;
using TazeBlog.Entities.Concrete;

namespace TazeBlog.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;
        private IArticleService _articleService;
        public CategoryController(ICategoryService categoryService, IArticleService articleService)
        {
            _categoryService = categoryService;
            _articleService = articleService;
        }
        public IActionResult List(string id)
        {
            Category category = _categoryService.Get("Permalink='" + id + "'");
            List<Article> articles = _articleService.GetAll("CategoryId='" + category.Id + "'");

            if(articles.Count == 0) { return RedirectToAction("Index", "Home"); }

            List<ArticleCategory> ArticleCategoryModel = articles.Select(x => new ArticleCategory
            {
                Categories = new List<Entities.Concrete.Category>
                {
                    category
                },
                Name = x.Name,
                Content = x.Content,
                Permalink = x.Permalink
            }).ToList();
            return View(ArticleCategoryModel);
        }
    }
}