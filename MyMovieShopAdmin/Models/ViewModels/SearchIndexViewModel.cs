using MovieShopDll;
using MovieShopDll.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMovieShopAdmin.Models.ViewModels
{
    public class SearchIndexViewModel
    {
        public List<Movie> Movies { get; set; }
        public Pager Pager { get; set; }
        public int LastSelectedMoviesPerPage { get; set; }
        public string LastSelectedGenre { get; set; }
        public string LastSelectedOrderBy { get; set; }
    }
}