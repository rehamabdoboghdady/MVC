using BL.Services;
using BL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace web.Controllers
{
    [HandleError]
  [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryService categoryService = new CategoryService();

        public ActionResult Index()
        {

            return View(categoryService.GetAllCategory());
        }
        public ActionResult Create() => View();

        [HttpPost]
        public ActionResult Create(CategoryViewModel newCategory)
        {

            if (ModelState.IsValid == false)
                return View(newCategory);
            categoryService.SaveNewCategory(newCategory);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {

            categoryService.GetCategory(id);
            categoryService.DeleteCategory(id);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(categoryService.GetCategory(id));
        }

        [HttpPost]
        public ActionResult Edit(CategoryViewModel newCategory)
        {

            if (ModelState.IsValid == false)
                return View(newCategory);
            categoryService.UpdateCategory(newCategory);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {

            return View(categoryService.GetCategory(id));
        }

   }
}