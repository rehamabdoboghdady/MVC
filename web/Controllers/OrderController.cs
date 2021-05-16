using BL.Services;
using BL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace web.Controllers
{
 //   [Authorize]
    public class OrderController : Controller
    {
        // GET: Order
       OrderService orderService = new OrderService();
        // GET: Order
        public ActionResult Index()
        {
            return View(orderService.GetAllOrder());
        }
        public ActionResult Create()=> View();
        
        [HttpPost]
        public ActionResult Create(OrderDetailsViewModel newOrder)
        {
            if (ModelState.IsValid == false)
                return View(newOrder);
            orderService.SaveNewOrder(newOrder);
            return RedirectToAction("Index"); 
        }
        public ActionResult Delete(int id)
        {
            orderService.GetOrder(id);
            orderService.DeleteOrder(id);
         

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(orderService.GetOrder(id));
        }

        [HttpPost]
        public ActionResult Edit(OrderDetailsViewModel newOrder)
        {

            if (ModelState.IsValid == false)
                return View(newOrder);
            orderService.UpdateOrder(newOrder);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {


            return View(orderService.GetOrder(id));

        }


    }
}