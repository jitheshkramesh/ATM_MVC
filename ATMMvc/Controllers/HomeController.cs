using ATMMvc.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATMMvc.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var Membership = db.CheckingAccounts.Where(s => s.ApplicationUserId.Equals(userId.ToString())).Count();
            if (Membership > 0)
            {
                var checkingAccountId = db.CheckingAccounts.Where(c => c.ApplicationUserId == userId).First().Id;
                ViewBag.CheckingAccountId = checkingAccountId;
            }
            else { ViewBag.CheckingAccountId = "1"; }
            var manager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindById(userId);
            ViewBag.pin = user.pin;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Foo()
        {
            return View("About");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(string Message)
        {
            ViewBag.TheMessage = "Thanks for your message";

            return PartialView("_ContactThanks");
        }

        public ActionResult Serial(String letterCase)
        {
            var serial = "ASPNETMVC5ATM1";
            if (letterCase == "lower")
            {
                return Content(serial.ToLower());
            }
            return Content(serial);
        }
    }
}