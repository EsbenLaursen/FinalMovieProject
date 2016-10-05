using MovieShopDll;
using MovieShopDll.Entities;
using MyMovieShopAdmin.Models.ViewModels;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using System;

namespace MyMovieShopAdmin.Controllers
{
  

    public class HomeController : ApplicationController
    {
        IManager<Movie> mm = new DllFacade().GetMovieManager();
        IManager<Customer> cm = new DllFacade().GetCustomerManager();
        IManager<Order> om = new DllFacade().GetOrderManager();
        IManager<Genre> gm = new DllFacade().GetGenreManager();
        //    CartItems cc = new CartItems();


        public ActionResult Index()
        {
                //ViewModel
                HomeIndexViewModel viewModel = new HomeIndexViewModel() {
                    MoviesInCart = mm.Read(),
                    Movies = mm.Read(),
                    Genres = gm.Read()
                };
            return View(viewModel);

            
        }
        [Authorize]
        public ActionResult About()
        {

            // User.Identity.GetUserId(); // doesn't work????


            //SKAL LAVES
            int id;
            // Using session then
            try
            {
                id = (int)Session["Id"];
                CurrentUser.Customer = cm.Read(id);
            }
            catch (Exception)
            {
                id = 1;
            }

            if (id != 0)
            {
                CurrentUser.Customer = cm.Read(id);
            }
            //never called?
            if(CurrentUser.Customer == null)
            {
                CurrentUser.Customer = cm.Read(1);
            }

            //ViewModel
            HomeIndexViewModel viewModel = new HomeIndexViewModel()
            {
                Customer = CurrentUser.Customer,
                Orders = om.Read().Where(x => x.Customer.Id == CurrentUser.Customer.Id).ToList() //Fetches the customer, his address and his orders
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult About(Customer c, Address a)
        {
           
            
            HomeIndexViewModel viewModel;
            if (ModelState.IsValid)
            {
                c.Address = a;
                c.Id = CurrentUser.Customer.Id;
                Customer updated = cm.Update(c);
                CurrentUser.Customer = updated;
                viewModel = new HomeIndexViewModel()
                {
                    Customer = CurrentUser.Customer,
                    Orders = om.Read().Where(x => x.Customer.Id == updated.Id).ToList() //Fetches the customer, his address and his orders
                };
                return View(viewModel);
            }
            //ViewModel
            viewModel = new HomeIndexViewModel()
            {
                Customer = CurrentUser.Customer,
                Orders = om.Read().Where(x => x.Customer.Id == CurrentUser.Customer.Id).ToList() //Fetches the customer, his address and his orders
            };
            return View(viewModel);
        }



        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
    }
}