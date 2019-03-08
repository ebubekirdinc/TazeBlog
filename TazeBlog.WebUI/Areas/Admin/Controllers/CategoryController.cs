using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TazeBlog.Business.Abstract;
using TazeBlog.Entities.Concrete;

namespace TazeBlog.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class CategoryController : BaseController
    {
        private ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        #region HttpGet
        [HttpGet]
        public IActionResult Index()
        {
            List<Category> categories = _categoryService.GetAll();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Update(int entityId)
        {
            Category category = _categoryService.GetById(entityId);
            return View(category);
        }
        [HttpGet]
        public IActionResult Delete(int entityId)
        {
            _categoryService.Delete(new Category
            {
                Id = entityId
            });

            return RedirectToAction("Index");
        }
        #endregion

        [HttpPost]
        public IActionResult Create(Category category)
        {
            _categoryService.Add(category);

            return RedirectToAction("Index");
        }

        public IActionResult Update(Category category)
        {
            Category categoryItem = _categoryService.GetById(category.Id);
            categoryItem.Name = category.Name;
            categoryItem.Description = category.Description;
            categoryItem.Permalink = category.Permalink;

            _categoryService.Update(categoryItem);

            return RedirectToAction("Index");
        }
    }
}