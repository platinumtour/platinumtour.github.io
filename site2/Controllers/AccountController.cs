using site2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace site2.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                Registration user = null;
                using (CustomerContext db = new CustomerContext())
                {
                    user = db.Users.FirstOrDefault(u => u.email == model.Name);
                }
                if (user == null)
                {
                    // создаем нового пользователя
                    using (CustomerContext db = new CustomerContext())
                    {
                        db.Users.Add(new Registration { email = model.Name, password = model.Password });
                        db.SaveChanges();

                        user = db.Users.Where(u => u.email == model.Name && u.password == model.Password).FirstOrDefault();
                    }
                    // если пользователь удачно добавлен в бд
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Name, true);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                }
            }

            return View(model);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                // поиск пользователя в бд
                Registration user = null;
                using (CustomerContext db = new CustomerContext())
                {
                    user = db.Users.FirstOrDefault(u => u.email == model.Name && u.password == model.Password);

                }
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Name, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                }
            }

            return View(model);
        }

        [Authorize]
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}