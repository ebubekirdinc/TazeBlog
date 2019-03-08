using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TazeBlog.Business.Abstract;
using TazeBlog.Entities.ComplexTypes;
using TazeBlog.Entities.Concrete;

namespace TazeBlog.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class ArticleController : BaseController
    {
        private IArticleService _articleService;
        private ICategoryService _categoryService;
        public ArticleController(IArticleService articleService, ICategoryService categoryService)
        {
            _articleService = articleService;
            _categoryService = categoryService;
        }

        #region HttpGet

        [HttpGet]
        public IActionResult Index()
        {
            List<Article> articles = _articleService.GetAll();
            List<Category> categories = _categoryService.GetAll();

            var ArticleCategoryModel = articles.Select(x => new ArticleCategory
            {
                Categories = new List<Category> { _categoryService.GetById(x.CategoryId) },
                Content = x.Content,
                Name = x.Name,
                Id = x.Id
            });
            return View(ArticleCategoryModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ArticleCategory pocoModel = new ArticleCategory()
            {
                Categories = _categoryService.GetAll()
            };
            return View(pocoModel);
        }

        [HttpGet]
        public IActionResult Update(int entityId)
        {
            Article article = _articleService.GetById(entityId);
            ArticleCategory pocoModel = new ArticleCategory()
            {
                Id = article.Id,
                Name = article.Name,
                Content = article.Content,
                CategoryId = article.CategoryId,
                Permalink=article.Permalink,
                Categories = _categoryService.GetAll()
            };

            return View(pocoModel);
        }

        [HttpGet]
        public IActionResult Delete(int entityId)
        {
            _articleService.Delete(new Article { Id = entityId });
            return RedirectToAction("Index");
        }

        #endregion

        #region HttpPost
        [HttpPost]
        public IActionResult Create(Article article)
        {
            _articleService.Add(article);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(Article article)
        {
            Article articleItem = _articleService.GetById(article.Id);
            articleItem.Name = article.Name;
            articleItem.Content = article.Content;
            articleItem.CategoryId = article.CategoryId;
            articleItem.Permalink = article.Permalink;

            _articleService.Update(articleItem);

            return RedirectToAction("Index");
        }

        #endregion

    }
}