using MovieShopDll.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMovieShopAdmin.Models.ViewModels
{
    public class HomeShoppingCartViewModel 
    {
        public List<Movie> Movies { get; set; }
        public double TotalPrice { get { return Movies.Sum(x=> x.Price); } set { } }

    }
}