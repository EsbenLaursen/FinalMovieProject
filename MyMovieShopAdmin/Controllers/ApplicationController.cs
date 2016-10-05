using MovieShopDll;
using MovieShopDll.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMovieShopAdmin.Controllers
{
    public abstract class ApplicationController : Controller
    {
        public ApplicationController()
        {
            ViewData["ItemsInCart"] = CartItems.Movies.Count;
        }

    }
}