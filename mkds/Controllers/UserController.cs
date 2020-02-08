using mkds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mkds.Controllers
{
    public class UserController : Controller
    {
        // GET: User

        public ActionResult Index()
        {

            return View();
        }

       
        public ActionResult Login()
        {
            return PartialView("Login");
        }

        [HttpPost]
        public JsonResult Login(string name, string password)
        {
            User objUserLogin = new User();
            objUserLogin.name = name;
            objUserLogin.password = password;

            var u = UserRepository.Users.FirstOrDefault(x => x.name == objUserLogin.name && x.password == objUserLogin.password);

            if (u != null)
            {
                Session["user"] = u;
                return Json(true, JsonRequestBehavior.AllowGet);
            }
         
            else
            {

                return Json(false, JsonRequestBehavior.AllowGet);
            }
             
        }

        public ActionResult Profile()
        {

            return View();
        }
    

    }
}