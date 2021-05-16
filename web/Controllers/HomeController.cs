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
    public class HomeController : Controller
    {
        ProductService productService = new ProductService();
        CategoryService categoryService = new CategoryService();
        public ActionResult Index()
        {
            return View(productService.GetAllProduct());
        }
        public ActionResult Search(string productName)
        {
            ViewBag.categories = categoryService.GetAllCategory();
            List<ProductViewModel> productViewModels = productService.Search(productName);
            return View("index", productViewModels);
        }


        public ActionResult GetProductsByCategory(int id)
        {
     
            ViewBag.categories = categoryService.GetAllCategory();
            return View("index", productService.GetAllProduct().Where(p => p.CategoryID == id).ToList());
        }

        public ActionResult Details(int id)
        {


            return View(productService.GetProduct(id));

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}