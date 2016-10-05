using MovieShopDll.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDll
{
    public class CartItems
    {
        public static List<Movie> Movies = new List<Movie>();
        public List<Movie> getMovies()
        {
            return Movies;
        }
    }

}
