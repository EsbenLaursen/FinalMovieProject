using MovieShopDll.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDll
{
    public class SearchCriteria
    {
        public string OrderBy { get; set; }
        public string SearchQuery { get; set; }
        public string Genre { get; set; }
        public int ItemsPerPage { get; set; }
        public static int PerPage { get; set; }
        public static List<Movie> Movies { get; set; }
        public static string OrderByStatic { get; set; }
        public static string GenreBy { get; set; }


        public bool MatchesCriteria(SearchCriteria s, Movie movie)
        {
           

            bool matches = false;
            foreach (var genre in movie.Genres)
            {
                if (genre.Name.ToLower() == s.Genre.ToLower())
                {
                    matches = true;
                }
            }
            if (s.SearchQuery.ToLower().Contains(movie.Title.ToLower()))
            {
                matches = true;
            }
            return matches;
        }
    }


}
