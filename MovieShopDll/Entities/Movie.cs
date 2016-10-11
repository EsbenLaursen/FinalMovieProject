using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDll.Entities
{
    public class Movie : AbstractEntity
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public string TrailerUrl { get; set; }
        public virtual List<Genre> Genres { get; set; }

    }
}
