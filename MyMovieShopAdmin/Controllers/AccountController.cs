using MovieShopDll;
using MovieShopDll.Entities;
using MyMovieShopAdmin.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyMovieShopAdmin.Controllers
{
    public class AccountController : Controller
    {
        IManager<Customer> cm = new DllFacade().GetCustomerManager();
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Login()
        {
            return View();
        }


        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string ReturnUrl)
        {
     
            ViewBag.ReturnUrl= ReturnUrl;
            return View();
        }
        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Customer c, string ReturnUrl)
        {
            var user = cm.Read().Where(x => x.Email.Equals(c.Email) && x.password.Equals(c.password)).FirstOrDefault();
            if (user != null)
            {
                if (user.Role == "admin")
                {
                    return Redirect("http://localhost:64620//Home/index");
                }
                else
                {
                    Session["Id"] = user.Id;
                    FormsAuthentication.SetAuthCookie(user.FirstName, false);
                    return RedirectToLocal("../" + ReturnUrl);
                }
            }
            return View();
        }

        [Authorize]
        public ActionResult Logout()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("../Home/Index");
        }

        [HttpGet]
        public ActionResult CreateUser()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult CreateUser(Customer c)
        {
            if (c != null)
            {
                c.Role = "user";
                cm.Create(c);
                return RedirectToAction("Login");
            }
            return View();
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return RedirectToAction(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

    }
}