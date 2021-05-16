using AutoMapper;
using BL.Services;
using BL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace web.Controllers
{
    public class CartController : Controller
    {
        OrderDetailesService orderdetailsService = new OrderDetailesService();
        // GET: Order
        public ActionResult Index()
        {
            return View(orderdetailsService.GetAllOrderDetails());
        }
        public ActionResult Create() => View();

        [HttpPost]
        public ActionResult Create(OrderDetailesViewModel newOrderDetails)
        {
            if (ModelState.IsValid == false)
                return View(newOrderDetails);
            orderdetailsService.SaveNewOrderDetails(newOrderDetails);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            orderdetailsService.GetOrderDetails(id);
            orderdetailsService.DeleteOrderDetails(id);


            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(orderdetailsService.GetOrderDetails(id));
        }

        [HttpPost]
        public ActionResult Edit(OrderDetailesViewModel newOrderDetails)
        {

            if (ModelState.IsValid == false)
                return View(newOrderDetails);
            orderdetailsService.UpdateOrderDetails(newOrderDetails);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {


            return View(orderdetailsService.GetOrderDetails(id));

        }
       

    }
}