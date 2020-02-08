using mkds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mkds.Controllers
{
    public class OrderController : Controller
    {
        private List<Order> orders;
        // GET: Order
        public ActionResult Index()
        {
            return View(orders);
        }

        public ActionResult Detail(int Id)
        {
            var order = orders.FirstOrDefault(x => x.order_id == Id);
            Session["order_id"] = Id;
            return View(orders);
        }

        public ActionResult Tracking()
        {
            return View();
        }
    }
}