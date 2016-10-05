using MovieShopDll;
using MovieShopDll.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMovieShopAdmin.Models.ViewModels
{
    public class HomeIndexViewModel 
    {
        public List<Movie> Movies { get; set; }
        public Customer Customer { get; set; }
        public List<Movie> MoviesInCart { get {
                return CartItems.Movies;
            } set { } }
        public List<Order> Orders { get; set; }

        public List<Genre> Genres { get; set; }
        public Pager Pager { get; set; }


    }
}