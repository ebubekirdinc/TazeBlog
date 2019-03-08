using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TazeBlog.Business.Abstract;

namespace TazeBlog.WebUI.Controllers
{
    public class ArticleController : Controller
    {
        private IArticleService _articleService;
        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }
        public IActionResult Detail(string id)
        {
            var article = _articleService.Get("Permalink='" + id + "'");
            return View(article);
        }
    }
}