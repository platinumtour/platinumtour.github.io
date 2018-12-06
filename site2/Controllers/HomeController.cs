using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using site2.Models;

namespace site2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FEEDBACK feedback)
        {
            using (platinumTourEntities db = new platinumTourEntities())
            {
                db.FEEDBACK.Add(new FEEDBACK
                {
                    name = feedback.name,
                    email = feedback.email,
                    feedback1 = feedback.feedback1
                });

                db.SaveChanges();

            }
            return View();
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