using BL.Services;
using BL.ViewModel;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace web.Controllers
{
    [HandleError]
   [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        ProductService productService = new ProductService();
        CategoryService categoryService = new CategoryService();
        // GET: Product
        public ActionResult Index()
        {
            return View(productService.GetAllProduct());
        }
        public ActionResult Create() => View();

        [HttpPost]
        public ActionResult Create(ProductViewModel newProduct)
        {
            if (ModelState.IsValid == false)
                return View(newProduct);

            productService.SaveNewProduct(newProduct);
            return RedirectToAction("Index");
        }
  
        public ActionResult Delete(int id)
        {
         
            productService.GetProduct(id);
            productService.DeleteProduct(id);
        
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
           return View(productService.GetProduct(id));
        }

        [HttpPost]
        public ActionResult Edit(ProductViewModel newProduct)
        {
          
            if (ModelState.IsValid == false)
                return View(newProduct);
            productService.UpdateProduct(newProduct);
            return RedirectToAction("Index");
        }
  
        public ActionResult Details(int id)
        {
            

                return View(productService.GetProduct(id));

        }

      

    }

}