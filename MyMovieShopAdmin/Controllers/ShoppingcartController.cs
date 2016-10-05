using MovieShopDll;
using MovieShopDll.Entities;
using MyMovieShopAdmin.DAL;
using MyMovieShopAdmin.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MyMovieShopAdmin.Controllers
{
    public class ShoppingcartController : ApplicationController
    {
        IManager<Movie> mm = new DllFacade().GetMovieManager();
        IManager<Customer> cm = new DllFacade().GetCustomerManager();

        IManager<Order> om = new DllFacade().GetOrderManager();

        // GET: Shoppingcart
        public ActionResult Index()
        {
            HomeShoppingCartViewModel viewModel = new HomeShoppingCartViewModel()
            {
                Movies = CartItems.Movies
            };
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            Movie m = CartItems.Movies.Find(x => x.Id == id);
            if (id.HasValue)
            {
                CartItems.Movies.Remove(m);
            }
            return RedirectToAction("index");
        }

        [HttpGet]
        [Authorize]
        public ActionResult Checkout()
        {
            Order o = new Order() { Date = DateTime.Now, Movies = CartItems.Movies, CustomerId= (int) Session["Id"] }; 

            using (var ctx = new MovieShopDBContext())
           {
               ctx.Orders.Add(o);
                ctx.SaveChanges();
            }


            CartItems.Movies = new List<Movie>(); //Resets the list
            return View();
        }

    }
}