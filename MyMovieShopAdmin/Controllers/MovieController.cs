using MovieShopDll;
using MovieShopDll.Entities;
using MyMovieShopAdmin.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMovieShopAdmin.Controllers
{
    public class MovieController : ApplicationController
    {
        IManager<Movie> mm = new DllFacade().GetMovieManager();
        // GET: Movie
        [HttpGet]
        public ActionResult Index(int id)
        {
            MoviesIndexViewModel viewModel = new MoviesIndexViewModel() {
                Movie = mm.Read(id)
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Added(int id)
        {
            CartItems.Movies.Add(mm.Read(id));
            return View();
        }
    }
}